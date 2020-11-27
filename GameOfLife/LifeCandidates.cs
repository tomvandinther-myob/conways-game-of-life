using System.Collections.Generic;

namespace GameOfLife
{
    struct LifeCandidate
    {
        public LifeCandidate(int x, int y)
        {
            X = x;
            Y = y;
            AliveNeighbours = 0;
        }
        
        public int X { get; }
        public int Y { get; }
        public int AliveNeighbours { get; set; }
    }
    public class LifeCandidates
    {
        HashSet<LifeCandidate> candidateSet = new HashSet<LifeCandidate>();
        
        public int AliveNeighbours { get; set; }

        public void AddCandidate(int x, int y)
        {
            var lifeCandidate = new LifeCandidate(x, y);
            var added = candidateSet.Add(lifeCandidate);
            if (!added)
            {
                candidateSet.TryGetValue()
            }
        }
    }
}