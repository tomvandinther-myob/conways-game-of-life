using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using Xunit;

namespace GameOfLife.Tests
{
    public class SimulationTest
    {
        [Theory]
        [InlineData(1, " #\n #\n #")]
        [InlineData(2, "\n###")]
        public void Simulation_Blinker_ShouldIterate(int ticks, string expectedOutput)
        {
            Coordinate.XGridSize = 10;
            Coordinate.YGridSize = 10;
            
            var definedStates = new DefinedInitialStates(StatePattern.Blinker);

            var stringRenderer = new StringRenderer('#');
            
            var clock = new ManualClock();

            var simulation = new Simulation(
                ticks,
                clock,
                stringRenderer,
                new ConsoleKeyboardController(),
                new God(definedStates.InitialState)
                );

            simulation.Start(null, null);
            
            clock.TickMany(ticks);

            Assert.Equal(expectedOutput, stringRenderer.Out);
        }
    }
}