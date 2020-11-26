using Xunit;

namespace GameOfLife.Tests
{
    public class CellDictionaryTest
    {
        [Fact]
        public void CellDictionary_SetGet_ShouldReturnSame()
        {
            var cellDictionary = new CellDictionary();
            var cellIn = new Cell();
            cellDictionary.Add(1, 1, cellIn);
            var cellOut = cellDictionary.Get(1, 1);
            
            Assert.Same(cellIn, cellOut);
        }
    }
}