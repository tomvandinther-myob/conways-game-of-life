using System.Collections.Generic;

namespace GameOfLife
{
    public interface IStateParser
    {
        public HashSet<Coordinate> InitialState { get; }
    }
}