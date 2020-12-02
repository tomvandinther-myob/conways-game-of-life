using System.Collections.Generic;

namespace GameOfLife
{
    public class God
    {
        private readonly CellDictionary _initialStateCellDictionary;
        public CellDictionary CellDictionary { get; private set; }

        public God(HashSet<Coordinate> initialState)
        {
            CellDictionary = GenerateCellDictionary(initialState);
            _initialStateCellDictionary = CellDictionary;
        }

        private static CellDictionary GenerateCellDictionary(HashSet<Coordinate> newDictSet)
        {
            var newCellDict = new CellDictionary();

            foreach (var coordinate in newDictSet)
            {
                newCellDict.Add(Cell.FromCoordinateSet(coordinate, newDictSet));
            }

            return newCellDict;
        }

        public void LoadInitialState()
        {
            CellDictionary = _initialStateCellDictionary;
        }

        public LifeCandidates TakeLife(HashSet<Coordinate> newDictSet)
        {
            var lifeCandidates = new LifeCandidates();

            foreach (var cell in CellDictionary)
            {
                lifeCandidates.AddCandidates(cell.GetEmptyNeighbours());

                var neighbourCount = cell.GetNeighbourCount();

                if (neighbourCount == 2 || neighbourCount == 3)
                {
                    newDictSet.Add(new Coordinate(cell.X, cell.Y));
                }
            }

            return lifeCandidates;
        }

        public void GiveLife(LifeCandidates lifeCandidates, HashSet<Coordinate> newDictSet)
        {
            foreach (var candidate in lifeCandidates)
            {
                if (candidate.AliveNeighbours == 3)
                {
                    newDictSet.Add(new Coordinate(candidate.X, candidate.Y));
                }
            }

            CellDictionary = GenerateCellDictionary(newDictSet);
        }
    }
}