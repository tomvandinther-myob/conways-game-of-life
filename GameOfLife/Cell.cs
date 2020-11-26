using System;

namespace GameOfLife
{
    public class Cell
    {
        private static int directionEnumLength = Enum.GetNames<Direction>().Length;
        private Cell[] _neighbours = new Cell[directionEnumLength];
        
        public void SetNeighbour(Cell neighbour, Direction direction)
        {
            _neighbours[(int) direction] = neighbour;
        }

        public Cell GetNeighbour(Direction direction)
        {
            return _neighbours[(int) direction];
        }
    }
}