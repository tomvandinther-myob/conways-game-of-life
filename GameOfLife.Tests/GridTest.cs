using System;
using System.Linq;
using Xunit;

namespace GameOfLife.Tests
{
    public class GridTest
    {
        [Theory]
        [InlineData(10, 10)]
        public void Grid_ShouldInstantiate(int width, int height)
        {
            var grid = new Grid(width, height);
            Assert.IsType<Grid>(grid);
        }
        
        [Theory]
        [InlineData(2, 2, null)]
        public void Grid_ShouldInstantiate_WithState(int width, int height, bool[][] state)
        {
            var grid = new Grid(width, height, state);
            Assert.IsType<Grid>(grid);
        }
        
        [Theory]
        [InlineData(-10, 10)]
        [InlineData(10, -10)]
        [InlineData(-10, -10)]
        [InlineData(0, 10)]
        [InlineData(10, 0)]
        [InlineData(0, 0)]
        public void Grid_InvalidDimensions_ShouldThrowException(int width, int height)
        {
            Assert.Throws<Exception>(() => new Grid(width, height));
        }
        
        [Theory]
        [InlineData(2, 2, new bool[][] {{false, false, false}, {false, false, false}, {false, false, false}})]
        public void Grid_InvalidState_ShouldThrowException(int width, int height, bool[][] state)
        {
            Assert.Throws<Exception>(() => new Grid(width, height, state));
        }
        
        
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
    }
}