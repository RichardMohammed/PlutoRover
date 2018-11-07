using System.Collections.Generic;
using System.Linq;

namespace PlutoRover.Library
{
    public class Grid
    {
        private readonly int _gridMaxWidth;
        private readonly int _gridMaxHeight;
        private readonly List<Coordinate> _obstacles;

        public Grid(int maxWidth = 100, int maxHeight = 100)
        {
            _gridMaxWidth = maxWidth;
            _gridMaxHeight = maxHeight;
        }

        public Grid(List<Coordinate> obstacles, int maxWidth = 100, int maxHeight = 100)
        {
            _gridMaxWidth = maxWidth;
            _gridMaxHeight = maxHeight;
            _obstacles = obstacles;
        }

        public Coordinate Move(Coordinate coordinates, Direction direction, bool isForward)
        {
            var x = coordinates.X;
            var y = coordinates.Y;

            switch (direction)
            {
                case Direction.N:
                    y = isForward ? (y + 1) % _gridMaxHeight : (y > 0 ? y - 1 : _gridMaxHeight - 1);
                    break;
                case Direction.E:
                    x = isForward ? (x + 1) % _gridMaxWidth : (x > 0 ? x - 1 : _gridMaxWidth - 1);
                    break;
                case Direction.S:
                    y = isForward ? y > 0 ? y - 1 : _gridMaxHeight - 1 : ((y + 1) % _gridMaxHeight);
                    break;
                case Direction.W:
                    x = isForward ? x > 0 ? x - 1 : _gridMaxWidth - 1 : ((x + 1) % _gridMaxWidth);
                    break;
                default:
                    return coordinates;
            }

            var nextCoordinate = new Coordinate(x, y);

            return IsObstacle(nextCoordinate) ? null : nextCoordinate;
        }

        private bool IsObstacle(Coordinate coordinate)
        {
            if (_obstacles == null || _obstacles.Count == 0)
                return false;

           return _obstacles.Any(c => c.X == coordinate.X && c.Y == coordinate.Y);
        }

    }
}
