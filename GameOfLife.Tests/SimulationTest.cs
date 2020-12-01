using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;
using Xunit;

namespace GameOfLife.Tests
{
    public class SimulationTest
    {
        [Fact]
        public void Simulation_Glider_SingleIteration()
        {
            var textParser = new TextParser("", new HashSet<char>{'#'});
            var stringInput = new []
            {
                "-#-",
                "-#-",
                "-#-"
            };
            
            Coordinate.XGridSize = 10;
            Coordinate.YGridSize = 10;
            
            var simulation = new Simulation(
                1,
                new ConsoleRenderer(),
                new KeyboardController(),
                new God(textParser.ParseFromString(stringInput))
                );

            var sw = new StringWriter();
            Console.SetOut(sw);
            
            simulation.Start();
            Thread.Sleep(1200);

            var outputString = sw.ToString();

            var expectedString = "\n▓▓▓";
            
            Assert.Equal(expectedString, outputString);
        }
    }
}