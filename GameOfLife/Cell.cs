using System;
using System.Collections.Generic;
using System.Linq;

namespace GameOfLife
{
    public class Cell
    {
        private static int directionEnumLength = Enum.GetNames<Direction>().Length;
        private bool[] _neighbours = new bool[directionEnumLength];
        public int X { get; }
        public int Y { get; }

        public Cell(Coordinate coordinate)
        {
            X = coordinate.X;
            Y = coordinate.Y;
        }
        
        public static Cell CreateCell(Coordinate coordinate, HashSet<Coordinate> newDictSet)
        {
            var cell = new Cell(coordinate);

            foreach (var direction in Enum.GetValues<Direction>())
            {
                var proposedNeighbour = coordinate.GetOffsetCoordinate(direction);
                if (newDictSet.Contains(proposedNeighbour))
                {
                    cell.SetNeighbour(direction);
                }
            }
            
            return cell;
        }

        public void SetNeighbour(Direction direction)
        {
            _neighbours[(int) direction] = true;
        }

        public int GetNeighbourCount()
        {
            return _neighbours.Count(exists => exists);
        }
        
        public List<Coordinate> GetEmptyNeighbours()
        {
            var emptyNeighbours = new List<Coordinate>();
            
            for (int i = 0; i < _neighbours.Length; i++)
            {
                var cell = _neighbours[i];
                if (cell != true)
                {
                    var coordinate = new Coordinate(X, Y);
                    coordinate.OffsetTo((Direction) i);
                    emptyNeighbours.Add(coordinate);
                }
            }

            return emptyNeighbours;
        }
    }
}