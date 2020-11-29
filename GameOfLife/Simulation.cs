using System.Collections.Generic;
using System.Threading;

namespace GameOfLife
{
    enum PlayState
    {
        Running,
        Stopped
    }
    
    public class Simulation
    {
        private int _tickCount = 0;
        private readonly int _maxIterations;
        private PlayState _playState = PlayState.Stopped;
        private readonly GridPrinter _gridPrinter;
        private readonly God _god;

        public Simulation(int maxIterations, GridPrinter gridPrinter, God god)
        {
            _maxIterations = maxIterations;
            _gridPrinter = gridPrinter;
            _god = god;
            // Simulation should stop when Main thread stops.
            var simulationThread = new Thread(Simulate) {IsBackground = true};
            simulationThread.Start();
        }

        public void Start()
        {
            _tickCount = 0;
            _playState = PlayState.Running;
        }

        public void Stop()
        {
            _playState = PlayState.Stopped;
            _tickCount = 0;
        }

        public void Resume()
        {
            _playState = PlayState.Running;
        }

        public void Pause()
        {
            _playState = PlayState.Stopped;
        }

        private void Tick()
        {
            var newDictSet = new HashSet<Coordinate>();
            var lifeCandidates = _god.TakeLife(_god.CellDictionary, newDictSet);
            _god.GiveLife(lifeCandidates, newDictSet);
            _gridPrinter.Print(_god.CellDictionary);
            _tickCount++;
        }

        private void Simulate()
        {
            while (_playState == PlayState.Running)
            {
                if (_tickCount < _maxIterations)
                {
                    Tick();
                    Thread.Sleep(200);
                }
                else
                {
                    break;
                }
            }
        }
    }
}