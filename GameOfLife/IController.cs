using System;

namespace GameOfLife
{
    public interface IController
    {
        public event EventHandler Reset;
        public event EventHandler TogglePlayState;
        public void Listen();
    }
}