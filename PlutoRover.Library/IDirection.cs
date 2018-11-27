namespace PlutoRover.Library
{
    public interface IDirection
    {
        CardinalDirection DirectionPoint { get; set; }
        CardinalDirection Left();
        CardinalDirection Right();
    }
}