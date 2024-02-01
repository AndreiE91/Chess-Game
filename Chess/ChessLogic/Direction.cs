namespace ChessLogic {
    // Useful class when generating moves, because all pieces move in certain directions
    // Represent direction as row delta and column delta == change in row and column from a given position
    public class Direction {
        // Define all possible directions
        public readonly static Direction North = new Direction(-1, 0);
        public readonly static Direction South = new Direction(1, 0);
        public readonly static Direction East = new Direction(0, 1);
        public readonly static Direction West = new Direction(0, -1);
        public readonly static Direction NorthEast = North + East;
        public readonly static Direction NorthWest = North + West;
        public readonly static Direction SouthEast = South + East;
        public readonly static Direction SouthWest = South + West;



        public int RowDelta { get; }
        public int ColumnDelta { get; }

        public Direction(int rowDelta, int columnDelta) {
            RowDelta = rowDelta;
            ColumnDelta = columnDelta;
        }

        // Override plus operator to be able to add two directions together
        public static Direction operator +(Direction dir1, Direction dir2) {
            return new Direction(dir1.RowDelta + dir2.RowDelta, dir1.ColumnDelta + dir2.ColumnDelta);
        }

        // Override multiply operator to be able to scale a direction
        public static Direction operator *(int scalar, Direction dir) {
            return new Direction(scalar * dir.RowDelta, scalar * dir.ColumnDelta);
        }
    }
}
