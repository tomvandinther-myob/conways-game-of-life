using System.Collections.Generic;

namespace GameOfLife
{
    public enum StatePattern
    {
        Glider,
        Blinker,
        Toad
    }
    
    public class DefinedInitialStates : IStateParser
    {
        public HashSet<Coordinate> InitialState { get; private set; }

        public DefinedInitialStates(StatePattern? statePattern)
        {
            switch (statePattern)
            {
                case StatePattern.Glider:
                    SetGlider();
                    break;
                case StatePattern.Blinker:
                    SetBlinker();
                    break;
                case StatePattern.Toad:
                    SetToad();
                    break;
                default:
                    SetGlider();
                    break;
            }
        }

        public void SetGlider()
        {
            InitialState = new HashSet<Coordinate>
            {
                new Coordinate(1, 0),
                new Coordinate(2, 1),
                new Coordinate(0, 2),
                new Coordinate(1, 2),
                new Coordinate(2, 2)
            };
        }
        
        public void SetBlinker()
        {
            InitialState = new HashSet<Coordinate>
            {
                new Coordinate(0, 1),
                new Coordinate(1, 1),
                new Coordinate(2, 1)
            };
        }
        
        public void SetToad()
        {
            InitialState = new HashSet<Coordinate>
            {
                new Coordinate(2, 1),
                new Coordinate(3, 1),
                new Coordinate(4, 1),
                new Coordinate(1, 2),
                new Coordinate(2, 2),
                new Coordinate(3, 2)
            };
        }
    }
}