using System;
using System.Collections.Generic;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            Coordinate.XGridSize = 100;
            Coordinate.YGridSize = 20;

            // var textParser = new TextParser(args[0], new HashSet<char>{'@', '#'});

            var definedStates = new DefinedInitialStates(StatePattern.Glider);
            
            var clock = new Clock(){ClockSpeed = ClockSpeed.Normal};
            var controller = new ConsoleKeyboardController();
            
            var simulation = new Simulation(
                clock,
                new ConsoleRenderer(),
                controller,
                new God(definedStates.InitialState)
                );
            
            controller.Listen();
        }
    }
}