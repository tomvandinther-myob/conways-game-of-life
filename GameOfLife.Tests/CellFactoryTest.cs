using Xunit;

namespace GameOfLife.Tests
{
    public class CellFactoryTest
    {
        [Fact]
        public void CellFactory_CreateCell_ShouldReturnCell()
        {
            var cellFactory = new CellFactory(10, 10, new CellDictionary());
            var cell = cellFactory.CreateCell(2, 2);

            Assert.IsType<Cell>(cell);
        }
    }
}