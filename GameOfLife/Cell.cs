using System;
using System.Collections.Generic;
using System.Linq;

namespace GameOfLife
{
    public class Cell
    {
        private static int directionEnumLength = Enum.GetNames<Direction>().Length;
        // private Cell[] _neighbours = new Cell[directionEnumLength];
        private bool[] _neighbours = new bool[directionEnumLength];
        public int X { get; }
        public int Y { get; }
        public bool Dead { get; private set; }

        public Cell(Coordinate coordinate)
        {
            X = coordinate.X;
            Y = coordinate.Y;
            Dead = false;
        }

        public void SetNeighbour(Direction direction)
        {
            _neighbours[(int) direction] = true;
        }
        
        // public void SetNeighbour(Cell neighbour, Direction direction)
        // {
        //     _neighbours[(int) direction] = neighbour;
        // }

        // public Cell GetNeighbour(Direction direction)
        // {
        //     ref var neighbour = ref _neighbours[(int) direction];
        //     if (neighbour is null || neighbour.Dead)
        //     {
        //         return null;
        //     }
        //     else if (neighbour.Dead)
        //     {
        //         neighbour = null;
        //         return neighbour;
        //     }
        //     else
        //     {
        //         return neighbour;
        //     }
        // }

        public int GetNeighbourCount()
        {
            // return _neighbours.Count(cell => cell != null && !cell.Dead);
            return _neighbours.Count(exists => exists);
        }
        
        public List<Coordinate> GetEmptyNeighbours()
        {
            var emptyNeighbours = new List<Coordinate>();
            
            for (int i = 0; i < _neighbours.Length; i++)
            {
                var cell = _neighbours[i];
                // if (cell is null || cell.Dead)
                if (cell != true)
                {
                    var coordinate = new Coordinate(X, Y);
                    coordinate.OffsetTo((Direction) i);
                    emptyNeighbours.Add(coordinate);
                }
            }

            return emptyNeighbours;
        }

        public void Die()
        {
            Dead = true;
        }
    }
}