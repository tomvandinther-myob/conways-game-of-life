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
                new GridPrinter(new ConsoleRenderer(), xGridSize, yGridSize),
                new God(initialState)
                );
            simulation.Start();
        }
    }
}