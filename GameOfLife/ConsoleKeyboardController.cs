using System;

namespace GameOfLife
{
    public class ConsoleKeyboardController : IController
    {
        public event EventHandler Play;
        public event EventHandler Stop;
        public event EventHandler Resume;
        public event EventHandler Pause;
        public event EventHandler TogglePlayState;

        public void Listen()
        {
            ConsoleKeyInfo cki;
            
            do
            {
                cki = Console.ReadKey(false);
                
                switch (cki.Key)
                {
                    case ConsoleKey.Spacebar:
                        OnTogglePlayState();
                        break;
                    case ConsoleKey.S:
                        OnStop();
                        break;
                }
                
            } while (cki.Key != ConsoleKey.Escape);
        }

        private void OnStop()
        {
            Stop?.Invoke(this, EventArgs.Empty);
        }

        private void OnPlay()
        {
            Play?.Invoke(this, EventArgs.Empty);
        }

        private void OnTogglePlayState()
        {
            TogglePlayState?.Invoke(this, EventArgs.Empty);
        }
    }
}