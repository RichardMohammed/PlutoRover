namespace PlutoRover.Library
{
    public class GridCell : IGridCell
    {
        public ICoordinate Coordinate { get; set; }
        public bool IsObstructedAhead { get; set; }
    }
}
