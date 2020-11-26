using System;
using System.Collections.Generic;

namespace GameOfLife
{
    public class Cell
    {
        private static int directionEnumLength = Enum.GetNames<Direction>().Length;
        private Cell[] _neighbours = new Cell[directionEnumLength];
        public int X { get; }
        public int Y { get; }
        private readonly int _xGridSize;
        private readonly int _yGridSize;

        public Cell(in int xPosition, in int yPosition, in int xGridSize, in int yGridSize)
        {
            X = xPosition;
            Y = yPosition;
            _xGridSize = xGridSize;
            _yGridSize = yGridSize;
        }

        public void SetNeighbour(Cell neighbour, Direction direction)
        {
            _neighbours[(int) direction] = neighbour;
        }

        public Cell GetNeighbour(Direction direction)
        {
            return _neighbours[(int) direction];
        }

        public List<Direction> GetEmptyNeighbours()
        {
            var emptyNeighbours = new List<Direction>();
            
            for (int i = 0; i < _neighbours.Length; i++)
            {
                var cell = _neighbours[i];
                if (cell is null)
                {
                    emptyNeighbours.Add((Direction) i);
                }
            }

            return emptyNeighbours;
        }
    }
}