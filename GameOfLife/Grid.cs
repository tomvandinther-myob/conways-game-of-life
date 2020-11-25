using System;
using System.Collections.Generic;

namespace GameOfLife
{
    public class Grid
    {
        public int Width { get; }
        public int Height { get; }
        public bool[][] State { get; }

        public Grid(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public Grid(in int width, in int height, bool[][] state)
        {
            Width = width;
            Height = height;
            if (state.GetLength(0) != width || state.GetLength(1) != height)
            {
                throw new Exception("Given state does not match the shape of the grid.");
            }
            State = state;
        }
    }
}