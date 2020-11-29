using System.Collections.Generic;

namespace GameOfLife
{
    public class God
    {
        private CellFactory _cellFactory;
        public CellDictionary CellDictionary { get; set; }
        
        public God(CellFactory cellFactory, HashSet<Coordinate> initialState)
        {
            _cellFactory = cellFactory;
            CellDictionary = GenerateCellDictionary(initialState);
        }

        public LifeCandidates TakeLife(CellDictionary cellDictionary, HashSet<Coordinate> newDictSet)
        {
            var lifeCandidates = new LifeCandidates();

            foreach (Cell cell in cellDictionary)
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
            foreach (LifeCandidate candidate in lifeCandidates)
            {
                if (candidate.AliveNeighbours == 3)
                {
                    newDictSet.Add(new Coordinate(candidate.X, candidate.Y));
                }
            }

            CellDictionary = GenerateCellDictionary(newDictSet);
        }

        private CellDictionary GenerateCellDictionary(HashSet<Coordinate> newDictSet)
        {
            var newCellDict = new CellDictionary();
            
            foreach (var coordinate in newDictSet)
            {
                newCellDict.Add(_cellFactory.CreateCell(coordinate, newDictSet));    
            }

            return newCellDict;
        }
    }
}