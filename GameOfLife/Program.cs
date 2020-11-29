using System;
using System.Collections.Generic;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            var maxIterations = 100;
            var xGridSize = 10;
            var yGridSize = 10;

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

            

            var simulation = new Simulation(
                maxIterations, 
                new GridPrinter(xGridSize, yGridSize),
                new God(new CellFactory(xGridSize, yGridSize), initialState)
                );
            simulation.Start();
        }
    }
}