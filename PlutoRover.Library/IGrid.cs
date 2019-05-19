namespace PlutoRover.Library
{
    public interface IGrid
    {
        IGridCell GetPosition(ICoordinate coordinates, CardinalDirection direction, bool isForward);
    }
}