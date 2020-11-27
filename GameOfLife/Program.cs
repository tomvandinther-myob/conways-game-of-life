using System;

namespace GameOfLife
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("▓  \n▓ ▓\n   ");
            var maxIterations = 100;
            var xGridSize = 10;
            var yGridSize = 10;
            var simulation = new Simulation(
                maxIterations, 
                new GridPrinter(xGridSize, yGridSize), 
                new God(new CellFactory(xGridSize, yGridSize))
                );
            simulation.Start();
        }
    }
}