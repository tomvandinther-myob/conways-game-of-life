namespace GameOfLife
{
    public class Coordinate
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        private (int X, int Y)[] _offsets =
        {
            (0, -1),
            (1, -1),
            (1, 0),
            (1, 1),
            (0, 1),
            (-1, 1),
            (-1, 0),
            (-1, -1)
        };

        public Coordinate(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public Coordinate GetOffsetCoordinate(Direction direction, (int X, int Y) moduloCoordsTuple)
        {
            var (x, y) = _offsets[(int) direction];
            var (modX, modY) = moduloCoordsTuple;
            return new Coordinate((X += x) % modX, (Y += y) % modY);
        }
        
        public void OffsetTo(Direction direction)
        {
            var (x, y) = _offsets[(int) direction];
            X += x;
            Y += y;
        }

        public override int GetHashCode()
        {
            return (X, Y).GetHashCode();
        }
    }
}