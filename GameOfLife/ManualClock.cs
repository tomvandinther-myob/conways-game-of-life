using System;

namespace GameOfLife.Tests
{
    public class ManualClock : IClock
    {
        public event EventHandler<int> Tick;
        public int TickCount { get; set; }

        public void Start()
        {
            
        }

        public void TickOnce()
        {
            TickCount++;
            Tick?.Invoke(this, TickCount);
        }

        public void TickMany(int ticks)
        {
            for (int i = 0; i < ticks; i++)
            {
                TickOnce();
            }
        }
    }
}