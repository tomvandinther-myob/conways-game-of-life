namespace GameOfLife
{
    public class CellFactory
    {
        private readonly int _xGridSize;
        private readonly int _yGridSize;
        private CellDictionary _cellDictionary;
        
        public CellFactory(int xGridSize, int yGridSize, CellDictionary cellDictionary)
        {
            _xGridSize = xGridSize;
            _yGridSize = yGridSize;
            _cellDictionary = cellDictionary;
        }

        public Cell CreateCell(int xPosition, int yPosition)
        {
            var cell = new Cell(xPosition, yPosition, _xGridSize, _yGridSize);

            // This repetition is hideous but I can't think of a dynamic implementation which is still readable.
            
            var eastNeighbour = _cellDictionary.Get((xPosition + 1) % _xGridSize, yPosition);
            var westNeighbour = _cellDictionary.Get((xPosition - 1) % _xGridSize, yPosition);
            var southNeighbour = _cellDictionary.Get(xPosition, (yPosition + 1) % _yGridSize);
            var northNeighbour = _cellDictionary.Get(xPosition, (yPosition - 1) % _yGridSize);
            
            var northeastNeighbour = _cellDictionary.Get((xPosition + 1) % _xGridSize, (yPosition - 1) % _yGridSize);
            var northwestNeighbour = _cellDictionary.Get((xPosition - 1) % _xGridSize, (yPosition - 1) % _yGridSize);
            var southeastNeighbour = _cellDictionary.Get((xPosition + 1) % _xGridSize, (yPosition + 1) % _yGridSize);
            var southwestNeighbour = _cellDictionary.Get((xPosition - 1) % _xGridSize, (yPosition + 1) % _yGridSize);
            
            if (eastNeighbour is not null) cell.SetNeighbour(eastNeighbour, Direction.East);
            if (westNeighbour is not null) cell.SetNeighbour(westNeighbour, Direction.West);
            if (southNeighbour is not null) cell.SetNeighbour(southNeighbour, Direction.South);
            if (northNeighbour is not null) cell.SetNeighbour(northNeighbour, Direction.North);
            
            if (northeastNeighbour is not null) cell.SetNeighbour(eastNeighbour, Direction.Northeast);
            if (northwestNeighbour is not null) cell.SetNeighbour(westNeighbour, Direction.Northwest);
            if (southeastNeighbour is not null) cell.SetNeighbour(southNeighbour, Direction.Southeast);
            if (southwestNeighbour is not null) cell.SetNeighbour(northNeighbour, Direction.Southwest);

            _cellDictionary.Add(cell);
            
            return cell;
        }
    }
}