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
        private const char CellChar = '▓';

        public GridPrinter(int xGridSize, int yGridSize)
        {
            this._yGridSize = yGridSize;
            this._xGridSize = xGridSize;
        }

        public string Print(CellDictionary aliveCells)
        {
            var gridString = new StringBuilder(GetEmptyGridString());
            
            foreach (Cell cell in aliveCells)
            {
                var stringIndex = cell.Y * (_xGridSize + 1) + cell.X;
                gridString[stringIndex] = CellChar;
            }

            return gridString.ToString();
        }

        private string GetEmptyGridString()
        {
            var gridString = new StringBuilder();

            for (int i = 0; i < _xGridSize; i++)
            {
                for (int j = 0; j < _yGridSize; j++)
                {
                    gridString.Append(' ');                    
                }
                gridString.Append('\n');    
            }

            gridString.Length--; // Remove the last '\n'
            return gridString.ToString();
        }
    }
}