using System;
using Xunit;

namespace GameOfLife.Tests
{
    public class GridTest
    {
        [Theory]
        [InlineData(10, 10)]
        [InlineData(15, 20)]
        [InlineData(1, 200)]
        public void Grid_ShouldReturnInitProperties(int expectedWidth, int expectedHeight)
        {
            var grid = new Grid(expectedWidth, expectedHeight);
            Assert.Equal(expectedHeight, grid.Height);
            Assert.Equal(expectedWidth, grid.Width);
        }

        [Theory]
        [InlineData(-10, 10)]
        [InlineData(10, -10)]
        [InlineData(-10, -10)]
        [InlineData(0, 10)]
        [InlineData(10, 0)]
        [InlineData(0, 0)]
        public void Grid_NegativeDimension_ShouldThrowException(int width, int height)
        {
            Assert.Throws<Exception>(() => new Grid(width, height));
        }
    }
}