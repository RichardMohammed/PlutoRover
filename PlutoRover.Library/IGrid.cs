namespace PlutoRover.Library
{
    public interface IGrid
    {
        IGridCell GetPosition(IGridCell coordinates, CardinalDirection direction, bool isForward);
    }
}