namespace GameOfLife
{
    public interface IRenderer
    {
        void Render(int iteration, CellDictionary simulationOutput);
    }
}