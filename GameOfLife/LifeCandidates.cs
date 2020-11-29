using System;
using System.Collections;
using System.Collections.Generic;

namespace GameOfLife
{
    public struct LifeCandidate
    {
        public LifeCandidate(Coordinate coordinate)
        {
            X = coordinate.X;
            Y = coordinate.Y;
            AliveNeighbours = 0;
        }
        
        public int X { get; }
        public int Y { get; }
        public int AliveNeighbours { get; set; }
    }
    public class LifeCandidates : IEnumerable<LifeCandidate>
    {
        Dictionary<Coordinate, LifeCandidate> candidateSet = new Dictionary<Coordinate, LifeCandidate>();
        
        public int AliveNeighbours { get; set; }

        public void AddCandidate(Coordinate coordinate)
        {
            try
            {
                var candidate = candidateSet[coordinate];
                candidate.AliveNeighbours++;
            }
            catch (KeyNotFoundException)
            {
                candidateSet[coordinate] = new LifeCandidate(coordinate);
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
            return candidateSet.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return candidateSet.Values.GetEnumerator();
        }
    }
}