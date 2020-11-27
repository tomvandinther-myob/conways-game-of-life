using System.Collections.Generic;

namespace GameOfLife
{
    public class God
    {
        private CellFactory _cellFactory;
        public God(CellFactory cellFactory)
        {
            _cellFactory = cellFactory;
        }

        public LifeCandidates TakeLife(CellDictionary cellDictionary)
        {
            var lifeCandidates = new HashSet<LifeCandidates>();
            
            throw new System.NotImplementedException();
        }
        
        public void GiveLife(LifeCandidates lifeCandidates, CellDictionary cellDictionary)
        {
            throw new System.NotImplementedException();
        }
    }
}