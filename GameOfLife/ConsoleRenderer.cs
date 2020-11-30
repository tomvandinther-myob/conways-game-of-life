using System;

namespace GameOfLife
{
    public class ConsoleRenderer : IRenderer
    {
        public ConsoleRenderer()
        {
            Console.BackgroundColor = ConsoleColor.DarkGray;
            Console.ForegroundColor = ConsoleColor.Cyan;
        }

        public void Write(string output)
        {
            Console.Clear();
            Console.Write(output);
        }
    }
}