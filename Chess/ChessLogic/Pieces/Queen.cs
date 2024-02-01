namespace ChessLogic {
    public class Queen : Piece {
        public override PieceType Type => PieceType.Queen;
        public override Player Color { get; }

        public Queen(Player color) {
            Color = color;
        }

        private static readonly Direction[] dirs = new Direction[] {
            Direction.North,
            Direction.South,
            Direction.East,
            Direction.West,
            Direction.NorthWest,
            Direction.NorthEast,
            Direction.SouthWest,
            Direction.SouthEast
        };

        public override Piece Copy() {
            Queen copy = new Queen(Color);
            copy.HasMoved = HasMoved;
            return copy;
        }

        public override IEnumerable<Move> GetMoves(Position from, Board board) {
            // This gives us all reachable positions
            return MovePositionsInDirs(from, board, dirs).Select(to => new NormalMove(from, to));
        }
    }
}
