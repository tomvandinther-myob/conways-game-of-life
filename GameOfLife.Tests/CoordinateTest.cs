using System.Collections;
using System.Collections.Generic;
using Xunit;

namespace GameOfLife.Tests
{
    public struct CoordinateTestData
    {
        public (int X, int Y) input;
        public (int X, int Y) expected;
        public (int X, int Y) gridSize;
    }

    public class CoordinateTest
    {
        public static IEnumerable<object[]> GetModuloTestTuples()
        {
            yield return new object[] { new CoordinateTestData
            {
                input = (4, 5),
                expected = (4, 0),
                gridSize = (5, 5)
            }};
            
            yield return new object[] { new CoordinateTestData
            {
                input = (5, 2),
                expected = (0, 2),
                gridSize = (5, 5)
            }};
        }
        
        [Theory]
        [MemberData(nameof(GetModuloTestTuples))]
        public void Coordinate_Constructor_ShouldModuloWithinGrid(CoordinateTestData data)
        {
            Coordinate.XGridSize = data.gridSize.X;
            Coordinate.YGridSize = data.gridSize.Y;
            
            var coordinate = new Coordinate(data.input.X, data.input.Y);
            
            Assert.Equal(data.expected.X, coordinate.X);
            Assert.Equal(data.expected.Y, coordinate.Y);
        }
        
        public struct DirectionCoordinateTestData
        {
            public Direction direction;
            public (int X, int Y) input;
            public (int X, int Y) expected;
            public (int X, int Y) gridSize;
        }
        
        public static IEnumerable<object[]> GetOffsetTestTuples()
        {
            // North Test
            yield return new object[] { new DirectionCoordinateTestData
            {
                direction = Direction.North,
                input = (0, 0),
                expected = (0, 4),
                gridSize = (5, 5),
            }};
            // Northeast Test
            yield return new object[] { new DirectionCoordinateTestData
            {
                direction = Direction.Northeast,
                input = (0, 0),
                expected = (1, 4),
                gridSize = (5, 5)
            }};
            // East Test
            yield return new object[] { new DirectionCoordinateTestData
            {
                direction = Direction.East,
                input = (0, 0),
                expected = (1, 0),
                gridSize = (5, 5)
            }};
            // Southeast Test
            yield return new object[] { new DirectionCoordinateTestData
            {
                direction = Direction.Southeast,
                input = (0, 0),
                expected = (1, 1),
                gridSize = (5, 5)
            }};
            // South Test
            yield return new object[] { new DirectionCoordinateTestData
            {
                direction = Direction.South,
                input = (0, 0),
                expected = (0, 1),
                gridSize = (5, 5)
            }};
            // Southwest Test
            yield return new object[] { new DirectionCoordinateTestData
            {
                direction = Direction.Southwest,
                input = (0, 0),
                expected = (4, 1),
                gridSize = (5, 5)
            }};
            // West Test
            yield return new object[] { new DirectionCoordinateTestData
            {
                direction = Direction.West,
                input = (0, 0),
                expected = (4, 0),
                gridSize = (5, 5)
            }};
            // Northwest Test
            yield return new object[] { new DirectionCoordinateTestData
            {
                direction = Direction.Northwest,
                input = (0, 0),
                expected = (4, 4),
                gridSize = (5, 5)
            }};
        }

        [Theory]
        [MemberData(nameof(GetOffsetTestTuples))]
        public void Coordinate_GetOffsetCoordinate_ShouldReturnOffsetCoordinate(DirectionCoordinateTestData data)
        {
            Coordinate.XGridSize = data.gridSize.X;
            Coordinate.YGridSize = data.gridSize.Y;
            
            var testCoordinate = new Coordinate(data.input.X, data.input.Y);

            var output = testCoordinate.GetOffsetCoordinate(data.direction);

            Assert.IsType<Coordinate>(output);
            Assert.Equal(data.expected.X, output.X);
            Assert.Equal(data.expected.Y, output.Y);
        }
        
        [Theory]
        [MemberData(nameof(GetOffsetTestTuples))]
        public void Coordinate_OffsetTo_ShouldChangeXY(DirectionCoordinateTestData data)
        {
            Coordinate.XGridSize = data.gridSize.X;
            Coordinate.YGridSize = data.gridSize.Y;
            
            var testCoordinate = new Coordinate(data.input.X, data.input.Y);

            testCoordinate.OffsetTo(data.direction);

            Assert.Equal(data.expected.X, testCoordinate.X);
            Assert.Equal(data.expected.Y, testCoordinate.Y);
        }

        [Fact]
        public void Coordinate_Equal()
        {
            var coordinate1 = new Coordinate(3, 2);
            var coordinate2 = new Coordinate(3, 2);
            
            Assert.Equal(coordinate1, coordinate2);
        }
        
        [Fact]
        public void Coordinate_NotEqual()
        {
            var coordinate1 = new Coordinate(3, 2);
            var coordinate2 = new Coordinate(3, 3);
            
            Assert.NotEqual(coordinate1, coordinate2);
        }
    }
}