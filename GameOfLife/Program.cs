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

            var textParser = new TextParser(args[0], new HashSet<char>{'@', '#'});

            var definedStates = new DefinedInitialStates(StatePattern.Glider);
            
            var clock = new Clock(){ClockSpeed = ClockSpeed.Fast};
            var controller = new ConsoleKeyboardController();

            IRenderer renderer;
            
            if (args.Length > 1)
            {
                var cellChar = char.Parse(args[1]);
                renderer = new ConsoleRenderer(cellChar);
            }
            else
            {
                renderer = new ConsoleRenderer();
            }
            
            var simulation = new Simulation(
                clock,
                renderer,
                controller,
                new God(textParser.InitialState)
                );
            
            // Listen is a blocking method. Exiting from this method exits the main thread.
            controller.Listen();
        }
    }
}