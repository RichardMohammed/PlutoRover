namespace PlutoRover.Library
{
    public interface IGrid
    {
        ICoordinate Move(ICoordinate coordinates, Direction direction, bool isForward);
    }
}