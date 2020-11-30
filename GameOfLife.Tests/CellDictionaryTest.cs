// using Xunit;
//
// namespace GameOfLife.Tests
// {
//     public class CellDictionaryTest
//     {
//         [Fact]
//         public void CellDictionary_SetGet_ShouldReturnSame()
//         {
//             var cellDictionary = new CellDictionary();
//             var cellIn = new Cell(1, 1, 3, 3);
//             cellDictionary.Add(cellIn);
//             var cellOut = cellDictionary.Get(1, 1);
//             
//             Assert.Same(cellIn, cellOut);
//         }
//     }
// }