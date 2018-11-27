using System.Reflection.Metadata;

namespace PlutoRover.Library
{
    public enum CardinalDirection
    {
        N, E, S, W
    }

    public class Direction : IDirection
    {
        public CardinalDirection DirectionPoint { get; set; }

        public CardinalDirection Left()
        {
            switch (DirectionPoint)
            {
                case CardinalDirection.N:
                    return CardinalDirection.W;
                case CardinalDirection.W:
                    return CardinalDirection.S;
                case CardinalDirection.S:
                    return CardinalDirection.E;
                default:
                    return CardinalDirection.N;
            }
        }

        public CardinalDirection Right()
        {
            switch (DirectionPoint)
            {
                case CardinalDirection.N:
                    return CardinalDirection.E;
                case CardinalDirection.E:
                    return CardinalDirection.S;
                case CardinalDirection.S:
                    return CardinalDirection.W;
                default:
                    return CardinalDirection.N;
            }
        }

    }

}
