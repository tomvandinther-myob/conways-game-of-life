using System;

namespace GameOfLife
{
    public interface IClock
    {
        public event EventHandler<int> Tick;
        public int TickCount { get; set; }
        
        public void Start();
    }
}