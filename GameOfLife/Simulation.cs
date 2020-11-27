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
        private int _maxIterations;
        private PlayState _playState = PlayState.Stopped;
        private GridPrinter _gridPrinter;
        private God _god;

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
            var cellDictionary = new CellDictionary();
            var lifeCandidates = _god.TakeLife(cellDictionary);
            _god.GiveLife(lifeCandidates, cellDictionary);
            cellDictionary.CommitStaged();
            _gridPrinter.Print(cellDictionary);
            _tickCount++;
        }

        private void Simulate()
        {
            while (_playState == PlayState.Running)
            {
                Tick();
                Thread.Sleep(200);
            }
        }
    }
}