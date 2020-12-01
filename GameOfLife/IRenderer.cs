namespace GameOfLife
{
    public interface IRenderer
    {
        void Render(CellDictionary simulationOutput);
    }
}