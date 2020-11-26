using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GameOfLife
{
    public class GridPrinter
    {
        private readonly int xGridSize;
        private readonly int yGridSize;

        public GridPrinter(int yGridSize, int xGridSize)
        {
            this.yGridSize = yGridSize;
            this.xGridSize = xGridSize;
        }

        public string Print(CellDictionary aliveCells)
        {
            var gridString = new StringBuilder(GetEmptyGridString());
            
            foreach (Cell cell in aliveCells)
            {
                var stringIndex = cell.Y * (xGridSize + 1) + cell.X;
                gridString[stringIndex] = '▓';
            }

            return gridString.ToString();
        }

        private string GetEmptyGridString()
        {
            var gridString = new StringBuilder();

            for (int i = 0; i < xGridSize; i++)
            {
                for (int j = 0; j < yGridSize; j++)
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