using System;
using System.Collections.Generic;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            var maxIterations = 1000;
            var xGridSize = 100;
            var yGridSize = 20;

            Coordinate.XGridSize = xGridSize;
            Coordinate.YGridSize = yGridSize;

            Console.WriteLine(args[0]);
            var textParser = new TextParser(args[0], new HashSet<char>{'@', '#'});

            var simulation = new Simulation(
                maxIterations, 
                new ConsoleRenderer(),
                new KeyboardController(),
                new God(textParser.InitialState)
                );
            simulation.Start();
        }
    }
}