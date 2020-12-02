using System.Linq;
using Xunit;

namespace GameOfLife.Tests
{
    public class CellDictionaryTest
    {
        [Fact]
        public void CellDictionary_ShouldEnumerate()
        {
            var cellDictionary = new CellDictionary();
            var cellIn = CellTest.GetTestCell();
            cellDictionary.Add(cellIn);
            var cellOut = cellDictionary.ToArray()[0];
            
            Assert.Same(cellIn, cellOut);
        }
    }
}