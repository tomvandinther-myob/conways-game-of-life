#nullable enable
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
        private readonly int? _maxIterations = null;
        private PlayState _playState = PlayState.Stopped;
        private readonly IClock _clock;
        private readonly IRenderer _renderer;
        private readonly IController _controller;
        private readonly God _god;

        public Simulation(IClock clock, IRenderer renderer, IController controller, God god)
        {
            _clock = clock;
            _renderer = renderer;
            _controller = controller;
            _god = god;

            _controller.TogglePlayState += TogglePlayState;
            _controller.Play += Start;
            _controller.Stop += Stop;
            
            _clock.Tick += Tick;
            _clock.Start();
            
            Render();
        }
        
        public Simulation(int maxIterations, IClock clock, IRenderer renderer, IController controller, God god) 
            : this(clock, renderer, controller, god)
        {
            _maxIterations = maxIterations;
        }

        public void Start(object? sender, EventArgs eventArgs)
        {
            _tickCount = 0;
            _playState = PlayState.Running;
        }

        public void TogglePlayState(object? sender, EventArgs eventArgs)
        {
            _playState = _playState != PlayState.Running ? PlayState.Running : PlayState.Stopped;
        }

        public void Stop(object? sender, EventArgs eventArgs)
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

        private void Tick(object? sender, int tickCount)
        {
            // Acts as a clutch on the clock. Intend to make and kill clock on changes instead.
            if (_playState != PlayState.Running) return;
            
            if (_maxIterations is not null && !(tickCount <= _maxIterations)) return;

            _tickCount++;
            var newDictSet = new HashSet<Coordinate>();
            var lifeCandidates = _god.TakeLife(newDictSet);
            _god.GiveLife(lifeCandidates, newDictSet);
            
            Render();
        }

        private void Render()
        {
            _renderer.Render(_god.CellDictionary);
        }
    }
}