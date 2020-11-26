using System.Collections.Generic;
using Xunit;

namespace GameOfLife.Tests
{
    public class GridPrinterTest
    {
        GridPrinter _gridPrinter = new GridPrinter();
        
        [Fact]
        public void GridPrinter_ShouldInstantiate()
        {
            Assert.IsType<GridPrinter>(_gridPrinter);
        }

        [Fact]
        // public void GridPrinter_Print_ShouldReturnGridString(CellDictionary aliveCells, string expectedResult)
        public void GridPrinter_Print_ShouldReturnGridString()
        {
            var aliveCells = new CellDictionary();
            
            aliveCells.Add(0, 0, new Cell());
            aliveCells.Add(0, 1, new Cell());
            aliveCells.Add(2, 1, new Cell());
            
            string expectedResult = "▓  \n▓ ▓\n   ";
            var result = GridPrinter.Print(aliveCells);
            Assert.Equal(expectedResult, result);
        }
    }
}