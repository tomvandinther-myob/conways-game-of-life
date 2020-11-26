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

            var eastNeighbour = _cellDictionary.Get(xPosition + 1, yPosition);
            var westNeighbour = _cellDictionary.Get(xPosition - 1, yPosition);
            var southNeighbour = _cellDictionary.Get(xPosition, yPosition + 1);
            var northNeighbour = _cellDictionary.Get(xPosition, yPosition - 1);
            
            if (eastNeighbour is not null) cell.SetNeighbour(eastNeighbour, Direction.East);
            if (westNeighbour is not null) cell.SetNeighbour(westNeighbour, Direction.West);
            if (southNeighbour is not null) cell.SetNeighbour(southNeighbour, Direction.South);
            if (northNeighbour is not null) cell.SetNeighbour(northNeighbour, Direction.North);

            _cellDictionary.Add(cell);
            
            return cell;
        }
    }
}