using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameOfLife
{
    public class ConsoleRenderer : IRenderer
    {
        private readonly StringRenderer _stringRenderer;
        private readonly char _cellChar;
        private const string Title = 
@"   ___                          _                  
  / __|___ _ ___ __ ____ _ _  _( )___              
 | (__/ _ \ ' \ V  V / _` | || |/(_-<              
  \___\___/_||_\_/\_/\__,_|\_, |_/__/    _  __     
    / __|__ _ _ __  ___   _|__/ _| | |  (_)/ _|___ 
   | (_ / _` | '  \/ -_) / _ \  _| | |__| |  _/ -_)
    \___\__,_|_|_|_\___| \___/_|   |____|_|_| \___|                              
";

        public ConsoleRenderer()
        {
            _stringRenderer = new StringRenderer();
            Console.ForegroundColor = ConsoleColor.Cyan;
        }
        
        public ConsoleRenderer(char cellChar)
        {
            _cellChar = cellChar;
            _stringRenderer = new StringRenderer(_cellChar);
        }

        public void Render(int iteration, CellDictionary simulationOutput)
        {
            _stringRenderer.Render(iteration, simulationOutput);
            Write(iteration, _stringRenderer.Out);
        }
        
        private static void Write(int iteration, string output)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(Title);
            Console.WriteLine("\n        Spacebar: Play/Pause | R: Reset | Esc: Exit");
            Console.WriteLine(" -----------------------------------------------------------");
            Console.WriteLine("                       Iteration: " + iteration);
            Console.WriteLine(" -----------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(output);
        }
    }
}