using System;
using System.Collections;
using System.Collections.Generic;

namespace GameOfLife
{
    public class CellDictionary : IEnumerable<Cell>
    {
        private readonly Dictionary<(int, int), Cell> _state = new Dictionary<(int, int), Cell>();

        public void Add(Cell cell)
        {
            _state[(cell.X, cell.Y)] = cell;
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