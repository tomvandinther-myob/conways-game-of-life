using System;
using System.Text;
using System.Threading;

namespace GameOfLife
{
    public enum ClockSpeed
    {
        VerySlow = 1000,
        Slow = 500,
        Normal = 250,
        Fast = 100,
        VeryFast = 25,
        GottaGoFast = 5
    }
    
    public class Clock : IClock
    {
        public ClockSpeed ClockSpeed { get; set; }
        public event EventHandler<int> Tick; 
        private readonly Thread _clockThread;
        public int TickCount { get; set; }

        public Clock()
        {
            ClockSpeed = ClockSpeed.Normal;
            _clockThread = new Thread(Run){ IsBackground = true };
        }

        public void Start()
        {
            _clockThread.Start();
        }

        private void Run()
        {
            while (true)
            {
                Thread.Sleep((int) ClockSpeed);
                TickCount++;
                OnTick(TickCount);
            }
        }

        protected virtual void OnTick(int tickCount)
        {
            Tick?.Invoke(this, tickCount);
        }
    }
}