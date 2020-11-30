using System;
using System.Collections;
using System.Collections.Generic;

namespace GameOfLife
{
    public class CellDictionary : IEnumerable<Cell>
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

        public bool Remove(Cell cell)
        {
            return _state.Remove((cell.X, cell.Y));
        }

        public bool Check(int x, int y)
        {
            return _state.ContainsKey((x, y));
        }

        public IEnumerator<Cell> GetEnumerator()
        {
            return _state.Values.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}