using System;

namespace GameOfLife
{
    public interface IController
    {
        public event EventHandler Play;
        public event EventHandler Stop;
        public event EventHandler Resume;
        public event EventHandler Pause;
        public event EventHandler TogglePlayState;
        public void Listen();
    }
}