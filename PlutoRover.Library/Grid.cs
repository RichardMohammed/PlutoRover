using System;
using System.Collections.Generic;
using System.Text;

namespace PlutoRover.Library
{
    public class Grid
    {
        private readonly int _gridMaxWidth;
        private readonly int _gridMaxHeight;

        public Grid()
        {
            _gridMaxWidth = 100;
            _gridMaxHeight = 100;
        }


        public Coordinate Reverse(Coordinate coordinates, Direction direction)
        {
            var x = coordinates.X;
            var y = coordinates.Y;

            switch (direction)
            {
                case Direction.N:
                    y = y > 0 ? y - 1 : _gridMaxHeight - 1;
                    break;
                case Direction.E:
                    x = x > 0 ? x - 1 : _gridMaxWidth - 1;
                    break;
                case Direction.S:
                    y = (y + 1) % _gridMaxHeight;
                    break;
                case Direction.W:
                    x = (x + 1) % _gridMaxWidth;
                    break;
                default:
                    return coordinates;
            }

            return new Coordinate(x, y);
        }


        public Coordinate MoveForward(Coordinate coordinates, Direction direction)
        {
            var x = coordinates.X;
            var y = coordinates.Y;

            switch (direction)
            {
                case Direction.N:
                    y = (y + 1) % _gridMaxHeight;
                    break;
                case Direction.E:
                    x = (x + 1) % _gridMaxWidth;
                    break;
                case Direction.S:
                    y = y > 0 ? y - 1 : _gridMaxHeight - 1;
                    break;
                case Direction.W:
                    x = x > 0 ? x - 1 : _gridMaxWidth - 1;
                    break;
                default:
                    return coordinates;
            }

            return new Coordinate(x, y);
        }

    }
}
