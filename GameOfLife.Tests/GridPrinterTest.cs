// using System.Collections.Generic;
// using Xunit;
//
// namespace GameOfLife.Tests
// {
//     public class GridPrinterTest
//     {
//         GridPrinter _gridPrinter = new GridPrinter(3, 3);
//         
//         [Fact]
//         public void GridPrinter_ShouldInstantiate()
//         {
//             Assert.IsType<GridPrinter>(_gridPrinter);
//         }
//
//         [Fact]
//         // public void GridPrinter_Print_ShouldReturnGridString(CellDictionary aliveCells, string expectedResult)
//         public void GridPrinter_Print_ShouldReturnGridString()
//         {
//             var gridPrinter = new GridPrinter(3, 3);
//             var aliveCells = new CellDictionary();
//             
//             aliveCells.Add(new Cell(0, 0, 3, 3));
//             aliveCells.Add(new Cell(0, 1, 3, 3));
//             aliveCells.Add(new Cell(2, 1, 3, 3));
//             
//             string expectedResult = "▓  \n▓ ▓\n   ";
//             var result = gridPrinter.Print(aliveCells);
//             Assert.Equal(expectedResult, result);
//         }
//     }
// }