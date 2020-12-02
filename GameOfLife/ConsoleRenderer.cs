using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameOfLife
{
    public class ConsoleRenderer : IRenderer
    {
        private StringRenderer _stringRenderer;
        private char _cellChar;

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

        public void Render(CellDictionary simulationOutput)
        {
            _stringRenderer.Render(simulationOutput);
            Write(_stringRenderer.Out);
        }
        
        private static void Write(string output)
        {
            Console.Clear();
            Console.Write(output);
        }
    }
}