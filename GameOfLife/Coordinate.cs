using System;
using System.Drawing;

namespace GameOfLife
{
    public class Coordinate
    {
        public static int XGridSize { get; set; }
        public static int YGridSize { get; set; }

        public int X { get; private set; }
        public int Y { get; private set; }

        private (int X, int Y)[] _offsets =
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
            X = Mod(x, XGridSize);
            Y = Mod(y, YGridSize);
        }

        private static int Mod(int n, int m)
        {
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
            var newX = Mod(X + x, XGridSize);
            var newY = Mod(Y + y, YGridSize);
            X = newX;
            Y = newY;
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