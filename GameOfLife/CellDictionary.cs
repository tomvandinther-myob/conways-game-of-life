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
            return _state[(x, y)];
        }

        public void Add(int x, int y, Cell cell)
        {
            _state[(x, y)] = cell;
        }

        public bool Remove(int x, int y)
        {
            return _state.Remove((x, y));
        }

        public bool Check(int x, int y)
        {
            return _state.ContainsKey((x, y));
        }

        public IEnumerator GetEnumerator()
        {
            return _state.GetEnumerator();
        }
    }
}