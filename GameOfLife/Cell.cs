using System;
using System.Collections.Generic;
using System.Linq;

namespace GameOfLife
{
    public class Cell
    {
        private readonly bool[] _neighbours = new bool[Enum.GetNames<Direction>().Length];
        public int X { get; }
        public int Y { get; }

        private Cell(Coordinate coordinate)
        {
            X = coordinate.X;
            Y = coordinate.Y;
        }
        
        public static Cell FromCoordinateSet(Coordinate coordinate, HashSet<Coordinate> newDictSet)
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

        private void SetNeighbour(Direction direction)
        {
            _neighbours[(int) direction] = true;
        }

        public int GetNeighbourCount()
        {
            return _neighbours.Count(exists => exists);
        }
        
        public IEnumerable<Coordinate> GetEmptyNeighbours()
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