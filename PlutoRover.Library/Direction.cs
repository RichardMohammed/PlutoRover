using System;
using System.Collections.Generic;
using System.Text;

namespace PlutoRover.Library
{
    public enum Direction
    {
        N,
        E,
        S,
        W
    }

    public static class DirectionMethods
    {
        public static Direction TurnLeft(this Direction direction)
        {
            switch (direction)
            {
                case Direction.N:
                    return Direction.W;
                case Direction.W:
                    return Direction.S;
                case Direction.S:
                    return Direction.E;
                default:
                    return Direction.N;
            }
        }

        public static Direction TurnRight(this Direction direction)
        {
            switch (direction)
            {
                case Direction.N:
                    return Direction.E;
                case Direction.E:
                    return Direction.S;
                case Direction.S:
                    return Direction.W;
                default:
                    return Direction.N;
            }
        }
    }

}
