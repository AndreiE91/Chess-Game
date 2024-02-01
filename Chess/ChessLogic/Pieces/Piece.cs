namespace ChessLogic {
    public abstract class Piece {
        public abstract PieceType Type { get; }
        public abstract Player Color { get; }
        // We need hasMoved because some moves are only legal if a piece has not moved yet (e.g. double pawn moves, castling)
        public bool HasMoved { get; set; } = false;
        public abstract Piece Copy();

        public abstract IEnumerable<Move> GetMoves(Position from, Board board);

        protected IEnumerable<Position> MovePositionsInDir(Position from, Board board, Direction dir) {
            for (Position pos = from + dir; Board.IsInside(pos); pos += dir) {

                // Empty square scenario
                if (board.IsEmpty(pos)) {
                    yield return pos;
                    continue;
                }

                // Piece encountered scenario
                Piece piece = board[pos];

                // If enemy piece, it can be captured
                if (piece.Color != Color) {
                    yield return pos;
                }

                // Else if allied piece it cannot be captured
                // Since bishop, queen or rook cannot jump, there are no more possible scenarios left to check
                yield break;
            }
        }

        protected IEnumerable<Position> MovePositionsInDirs(Position from, Board board, Direction[] dirs) {
            return dirs.SelectMany(dir => MovePositionsInDir(from, board, dir));
        }

        public virtual bool CanCaptureOpponentKing(Position from, Board board) {
            return GetMoves(from, board).Any(move => {
                Piece piece = board[move.ToPos];
                return piece != null && piece.Type == PieceType.King;
            });
        }

    }
}
