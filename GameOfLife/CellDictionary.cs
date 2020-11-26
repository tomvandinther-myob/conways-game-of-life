using System;
using System.Collections;
using System.Collections.Generic;

namespace GameOfLife
{
    public class CellDictionary : IEnumerable
    {
        private readonly Dictionary<(int, int), Cell> _state = new Dictionary<(int, int), Cell>();

        public Cell Get(int x, int y)
        {
            try
            {
                return _state[(x, y)];
            }
            catch (KeyNotFoundException)
            {
                return null;
            }
        }

        public void Add(Cell cell)
        {
            _state[(cell.X, cell.Y)] = cell;
        }

        public bool Remove(int x, int y)
        {
            return _state.Remove((x, y));
        }

        public bool Check(int x, int y)
        {
            return _state.ContainsKey((x, y));
        }

        public IEnumerator GetEnumerator() //TODO: Make type work???
        {
            return _state.Values.GetEnumerator();
        }
    }
}