using System;
using System.Collections;
using System.Collections.Generic;

namespace GameOfLife
{
    public class LifeCandidate
    {
        public int X { get; }
        public int Y { get; }
        public int AliveNeighbours { get; set; }
        
        public LifeCandidate(Coordinate coordinate)
        {
            X = coordinate.X;
            Y = coordinate.Y;
            AliveNeighbours = 1;
        }
    }
    public class LifeCandidates : IEnumerable<LifeCandidate>
    {
        private readonly Dictionary<Coordinate, LifeCandidate> _candidateSet = new Dictionary<Coordinate, LifeCandidate>();
        
        public void AddCandidate(Coordinate coordinate)
        {
            try
            {
                var candidate = _candidateSet[coordinate];
                candidate.AliveNeighbours++;
            }
            catch (KeyNotFoundException)
            {
                _candidateSet[coordinate] = new LifeCandidate(coordinate);
            }
        }

        public void AddCandidates(IEnumerable<Coordinate> coordinates)
        {
            foreach (var coordinate in coordinates)
            {
                AddCandidate(coordinate);
            }
        }
        
        public IEnumerator<LifeCandidate> GetEnumerator()
        {
            return _candidateSet.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}