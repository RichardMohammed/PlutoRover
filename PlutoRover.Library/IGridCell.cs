namespace PlutoRover.Library
{
    public interface IGridCell
    {
        ICoordinate Coordinate { get; set; }
        bool IsObstructedAhead { get; set; }
    }
}