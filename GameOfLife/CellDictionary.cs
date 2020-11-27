using System;
using System.Collections;
using System.Collections.Generic;

namespace GameOfLife
{
    public class CellDictionary : IEnumerable
    {
        private readonly Dictionary<(int, int), Cell> _state = new Dictionary<(int, int), Cell>();
        private List<Cell> _stagedAdditions = new List<Cell>();
        private List<Cell> _stagedDeletions = new List<Cell>();

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

        public void StageAdd(Cell cell)
        {
            _stagedAdditions.Add(cell);
        }

        public void StageRemove(Cell cell)
        {
            _stagedDeletions.Add(cell);
        }

        public bool Remove(int x, int y)
        {
            return _state.Remove((x, y));
        }

        public bool Check(int x, int y)
        {
            return _state.ContainsKey((x, y));
        }

        public void CommitStaged()
        {
            foreach (var cell in _stagedDeletions)
            {
                Remove(cell.X, cell.Y);
            }

            foreach (var cell in _stagedAdditions)
            {
                Add(cell);
            }
        }

        public IEnumerator GetEnumerator() //TODO: Make type work???
        {
            return _state.Values.GetEnumerator();
        }
    }
}