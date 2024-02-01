namespace ChessLogic {
    public class GameState {
        public Board Board { get;  }
        public Player CurrentPlayer { get; private set; }
        public Result Result { get; private set; } = null;

        private int noCaptureOrPawnMoves = 0;

        private string stateString;

        private readonly Dictionary<String, int> stateHistory = new Dictionary<string, int>();

        public GameState(Player player, Board board) {
            CurrentPlayer = player;
            Board = board;

            stateString = new StateString(CurrentPlayer, board).ToString();
            stateHistory[stateString] = 1;
        }

        public IEnumerable<Move> LegalMovesForPiece(Position pos) {
            // No legal moves if piece we want to move doesn't exist or is of opposite color
            if (Board.IsEmpty(pos) || Board[pos].Color != CurrentPlayer) {
                return Enumerable.Empty<Move>();
            }

            // Otherwise, get piece at current position and return all moves it can make
            Piece piece = Board[pos];
            IEnumerable<Move> moveCandidates = piece.GetMoves(pos, Board);
            return moveCandidates.Where(move => move.IsLegal(Board));
        }

        public void MakeMove(Move move) {

            Board.SetPawnSkipPosition(CurrentPlayer, null);

            bool captureOrPawn = move.Execute(Board);

            if (captureOrPawn) {
                noCaptureOrPawnMoves = 0;
                stateHistory.Clear(); // If a pawn was moved or piece was captured, it is impossible to encounter that state again
            } else {
                noCaptureOrPawnMoves++;
            }

            CurrentPlayer = CurrentPlayer.Opponent();
            UpdateStateString();
            CheckForGameOver();
        }

        public IEnumerable<Move> AllLegalMovesFor(Player player) {
            IEnumerable<Move> moveCandidates = Board.PiecePositionsFor(player).SelectMany(pos => {
                Piece piece = Board[pos];
                return piece.GetMoves(pos, Board);
            });

            return moveCandidates.Where(move => move.IsLegal(Board));
        }

        private void CheckForGameOver() {
            if (!AllLegalMovesFor(CurrentPlayer).Any()) {
                if (Board.IsInCheck(CurrentPlayer)) {
                    Result = Result.Win(CurrentPlayer.Opponent());
                } else {
                    Result = Result.Draw(EndReason.Stalemate);
                }
            } else if (Board.InsufficientMaterial()) {
                Result = Result.Draw(EndReason.InsufficientMaterial);
            } else if (FiftyMoveRule()) {
                Result = Result.Draw(EndReason.FiftyMoveRule);
            } else if (ThreefoldRepetition()) {
                Result = Result.Draw(EndReason.ThreefoldRepetition);
            }
        }

        public bool IsGameOver() {
            return Result != null;
        }

        private bool FiftyMoveRule() {
            int fullMoves = noCaptureOrPawnMoves / 2;

            return fullMoves == 50;
        }

        private void UpdateStateString() {
            stateString = new StateString(CurrentPlayer, Board).ToString();

            if(!stateHistory.ContainsKey(stateString)) {
                stateHistory[stateString] = 1;
            } else {
                stateHistory[stateString]++;
            }
        }

        private bool ThreefoldRepetition() {
            return stateHistory[stateString] == 3;
        }
    }
}
