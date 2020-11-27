namespace GameOfLife
{
    public class CellFactory
    {
        private readonly int _xGridSize;
        private readonly int _yGridSize;
        
        public CellFactory(int xGridSize, int yGridSize)
        {
            _xGridSize = xGridSize;
            _yGridSize = yGridSize;
        }

        public Cell CreateCell(int xPosition, int yPosition, CellDictionary cellDictionary)
        {
            var cell = new Cell(xPosition, yPosition, _xGridSize, _yGridSize);

            // This repetition is hideous but I can't think of a dynamic implementation which is still readable.
            
            var eastNeighbour = cellDictionary.Get((xPosition + 1) % _xGridSize, yPosition);
            var westNeighbour = cellDictionary.Get((xPosition - 1) % _xGridSize, yPosition);
            var southNeighbour = cellDictionary.Get(xPosition, (yPosition + 1) % _yGridSize);
            var northNeighbour = cellDictionary.Get(xPosition, (yPosition - 1) % _yGridSize);
            
            var northeastNeighbour = cellDictionary.Get((xPosition + 1) % _xGridSize, (yPosition - 1) % _yGridSize);
            var northwestNeighbour = cellDictionary.Get((xPosition - 1) % _xGridSize, (yPosition - 1) % _yGridSize);
            var southeastNeighbour = cellDictionary.Get((xPosition + 1) % _xGridSize, (yPosition + 1) % _yGridSize);
            var southwestNeighbour = cellDictionary.Get((xPosition - 1) % _xGridSize, (yPosition + 1) % _yGridSize);
            
            if (eastNeighbour is not null) cell.SetNeighbour(eastNeighbour, Direction.East);
            if (westNeighbour is not null) cell.SetNeighbour(westNeighbour, Direction.West);
            if (southNeighbour is not null) cell.SetNeighbour(southNeighbour, Direction.South);
            if (northNeighbour is not null) cell.SetNeighbour(northNeighbour, Direction.North);
            
            if (northeastNeighbour is not null) cell.SetNeighbour(eastNeighbour, Direction.Northeast);
            if (northwestNeighbour is not null) cell.SetNeighbour(westNeighbour, Direction.Northwest);
            if (southeastNeighbour is not null) cell.SetNeighbour(southNeighbour, Direction.Southeast);
            if (southwestNeighbour is not null) cell.SetNeighbour(northNeighbour, Direction.Southwest);

            return cell;
        }
    }
}