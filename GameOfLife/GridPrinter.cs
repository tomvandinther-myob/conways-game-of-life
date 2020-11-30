using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameOfLife
{
    public class GridPrinter
    {
        private readonly int _xGridSize;
        private readonly int _yGridSize;
        private readonly IRenderer _outputStream;
        private const char CellChar = '@'; //'▓';

        public GridPrinter(IRenderer outputStream, int xGridSize, int yGridSize)
        {
            _yGridSize = yGridSize;
            _xGridSize = xGridSize;
            _outputStream = outputStream;
        }

        public void Print(CellDictionary aliveCells)
        {
            var gridString = new StringBuilder(GetEmptyGridString());
            
            foreach (Cell cell in aliveCells)
            {
                var stringIndex = cell.Y * (_xGridSize + 1) + cell.X;
                gridString[stringIndex] = CellChar;
            }

            _outputStream.Write(gridString.ToString());
        }

        private string GetEmptyGridString()
        {
            var gridString = new StringBuilder();

            for (int i = 0; i < _yGridSize; i++)
            {
                for (int j = 0; j < _xGridSize; j++)
                {
                    gridString.Append(' ');
                }
                gridString.Append('\n');
            }

            // Remove the last '\n'
            gridString.Length--;
            
            return gridString.ToString();
        }
    }
}