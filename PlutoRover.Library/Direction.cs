using System.Collections.Generic;

namespace PlutoRover.Library
{
    public enum CardinalDirection
    {
        N, E, S, W
    }

    public class Direction : IDirection
    {
        public CardinalDirection DirectionPoint { get; set; }

        private readonly Dictionary<CardinalDirection, dynamic> _nextDirection =
            new Dictionary<CardinalDirection, dynamic>
            {
                { CardinalDirection.N, new{L = CardinalDirection.W, R = CardinalDirection.E}},
                { CardinalDirection.E, new{L = CardinalDirection.N, R = CardinalDirection.S}},
                { CardinalDirection.S, new{L = CardinalDirection.E, R = CardinalDirection.W}},
                { CardinalDirection.W, new{L = CardinalDirection.S, R = CardinalDirection.N}}
            };

        public CardinalDirection Left()
        {
            return _nextDirection[DirectionPoint].L;
        }

        public CardinalDirection Right()
        {
            return _nextDirection[DirectionPoint].R;
        }
    }
}
