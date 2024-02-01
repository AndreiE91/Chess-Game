namespace ChessLogic {
    public class Rook : Piece {
        public override PieceType Type => PieceType.Rook;
        public override Player Color { get; }

        public Rook(Player color) {
            Color = color;
        }

        private static readonly Direction[] dirs = new Direction[] {
            Direction.North,
            Direction.South,
            Direction.East,
            Direction.West
        };

        public override Piece Copy() {
            Rook copy = new Rook(Color);
            copy.HasMoved = HasMoved;
            return copy;
        }

        public override IEnumerable<Move> GetMoves(Position from, Board board) {
            // This gives us all reachable positions
            return MovePositionsInDirs(from, board, dirs).Select(to => new NormalMove(from, to));
        }
    }
}
