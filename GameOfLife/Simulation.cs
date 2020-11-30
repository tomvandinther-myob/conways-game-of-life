using System;
using System.Collections.Generic;
using System.Threading;

namespace GameOfLife
{
    internal enum PlayState
    {
        Running,
        Stopped
    }
    
    public class Simulation
    {
        private int _tickCount = 0;
        private readonly int _maxIterations;
        private PlayState _playState = PlayState.Stopped;
        private readonly IRenderer _renderer;
        private readonly God _god;

        public Simulation(int maxIterations, IRenderer renderer, God god)
        {
            _maxIterations = maxIterations;
            _renderer = renderer;
            _god = god;
            var simulationThread = new Thread(Simulate) {IsBackground = false};
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
            var lifeCandidates = _god.TakeLife(newDictSet);
            _god.GiveLife(lifeCandidates, newDictSet);
            _tickCount++;
        }

        private void Render()
        {
            _renderer.Render(_god.CellDictionary);
        }
        
        private void Simulate()
        {
            Render();
            Thread.Sleep(1000);
            while (true)
            {
                while (_playState == PlayState.Running)
                {
                    if (_tickCount < _maxIterations)
                    {
                        Tick();
                        Render();
                        Thread.Sleep(100);
                    }
                    else
                    {
                        break;
                    }
                }
                Thread.Sleep(100);
            }
        }
    }
}