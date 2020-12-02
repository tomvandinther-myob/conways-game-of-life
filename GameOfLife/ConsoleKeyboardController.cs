using System;

namespace GameOfLife
{
    public class ConsoleKeyboardController : IController
    {
        public event EventHandler Reset;
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
                    case ConsoleKey.R:
                        OnReset();
                        break;
                }
                
            } while (cki.Key != ConsoleKey.Escape);
        }

        private void OnReset()
        {
            Reset?.Invoke(this, EventArgs.Empty);
        }

        private void OnTogglePlayState()
        {
            TogglePlayState?.Invoke(this, EventArgs.Empty);
        }
    }
}