using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace GameOfLife.Tests
{
    public class CellTest
    {
        public static HashSet<Coordinate> GetTestCoordinateSet()
        {
            return new HashSet<Coordinate>
            {
                new Coordinate(0, 1),
                new Coordinate(2, 1),
                new Coordinate(2, 2)
            };
        }

        public static Coordinate GetTestCoordinate()
        {
            Coordinate.XGridSize = 5;
            Coordinate.YGridSize = 5;
            
            return new Coordinate(1, 1);
        }

        public static Cell GetTestCell()
        {
            var testCoordinate = GetTestCoordinate();
            var coordinateSet = GetTestCoordinateSet();

            return Cell.FromCoordinateSet(testCoordinate, coordinateSet);
        }

        [Fact]
        public void Cell_FromCoordinateSet_ShouldReturnNewCell()
        {
            var testCoordinate = GetTestCoordinate();
            var coordinateSet = GetTestCoordinateSet();

            var cell = Cell.FromCoordinateSet(testCoordinate, coordinateSet);

            Assert.IsType<Cell>(cell);
        }

        [Fact]
        public void Cell_GetNeighbourCount_ShouldReturnInt()
        {
            var cell = GetTestCell();

            var actual = cell.GetNeighbourCount();
            
            Assert.Equal(3, actual);
        }

        [Fact]
        public void Cell_GetEmptyNeighbours_ShouldReturnCoordinates()
        {
            var cell = GetTestCell();

            var emptyNeighbours = cell.GetEmptyNeighbours();

            Assert.IsAssignableFrom<IEnumerable<Coordinate>>(emptyNeighbours);
            Assert.Equal(5, emptyNeighbours.Count());
        }
    }
}