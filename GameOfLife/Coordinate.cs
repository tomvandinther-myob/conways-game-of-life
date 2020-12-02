#nullable enable

namespace GameOfLife
{
    public class Coordinate
    {
        public static int XGridSize { get; set; }
        public static int YGridSize { get; set; }

        private int _x;
        private int _y;
        
        public int X
        {
            get => _x;
            private set => _x = Mod(value, XGridSize); }
        public int Y
        {
            get => _y;
            private set => _y = Mod(value, YGridSize);
        }

        private readonly (int X, int Y)[] _offsets =
        {
            (0, -1), // North
            (1, -1), // Northeast
            (1, 0), // East
            (1, 1), // Southeast
            (0, 1), // South
            (-1, 1), // Southwest
            (-1, 0), // West
            (-1, -1) // Northwest
        };

        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
        }

        private static int Mod(int n, int m)
        {
            if (m <= 0) return n;
            return n < 0 ? ((n % m) + m) % m : n % m;
        }
        
        public Coordinate GetOffsetCoordinate(Direction direction)
        {
            var (x, y) = _offsets[(int) direction];
            return new Coordinate(X + x, Y + y);
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

        public override bool Equals(object? obj)
        {
            return obj is Coordinate && Equals((Coordinate) obj);
        }

        public bool Equals(Coordinate c)
        {
            return c.X == X && c.Y == Y;
        }
    }
}