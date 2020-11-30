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

            /* Glider
               ▓
                ▓
              ▓▓▓
            */
            var initialState = new HashSet<Coordinate>
            {
                new Coordinate(1, 3),
                new Coordinate(2, 1),
                new Coordinate(2, 3),
                new Coordinate(3, 2),
                new Coordinate(3, 3)
            };
            
            Console.WriteLine(args[0]);
            var textParser = new TextParser(args[0], new HashSet<char>{'@', '#'});
            
            // Funky Randomness
            // var initialState = new HashSet<Coordinate>
            // {
            //     new Coordinate(1, 2),
            //     new Coordinate(2, 2),
            //     new Coordinate(3, 2),
            //     new Coordinate(3, 2),
            //     new Coordinate(2, 2),
            //     new Coordinate(1, 1),
            //     new Coordinate(4, 3),
            //     new Coordinate(5, 4),
            //     new Coordinate(6, 3),
            //     new Coordinate(6, 4),
            //     new Coordinate(5, 3),
            //     new Coordinate(4, 4)
            // };

            // /* Oscillator
            //  
            //  */
            // var initialState = new HashSet<Coordinate>
            // {
            //     new Coordinate(4, 0),
            //     new Coordinate(0, 0),
            //     new Coordinate(3, 0)
            // };

            var simulation = new Simulation(
                maxIterations, 
                new ConsoleRenderer(),
                new God(textParser.InitialState)
                );
            simulation.Start();
        }
    }
}