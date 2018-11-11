using System.Collections.Generic;
using System.Linq;

namespace PlutoRover.Library
{
    public class Grid : IGrid
    {
        private readonly int _gridMaxWidth;
        private readonly int _gridMaxHeight;
        private readonly IEnumerable<ICoordinate> _obstacles;

        public Grid(IEnumerable<ICoordinate> obstacles = null, int maxWidth = 100, int maxHeight = 100)
        {
            _gridMaxWidth = maxWidth;
            _gridMaxHeight = maxHeight;
            _obstacles = obstacles;
        }

        public ICoordinate Move(ICoordinate coordinates, Direction direction, bool isForward)
        {
            var x = coordinates.X;
            var y = coordinates.Y;

            switch (direction)
            {
                case Direction.N:
                    y = isForward ? PositivePoint(y, _gridMaxHeight) : NegativePoint(y, _gridMaxHeight);
                    break;
                case Direction.E:
                    x = isForward ? PositivePoint(x, _gridMaxWidth) : NegativePoint(x, _gridMaxWidth);
                    break;
                case Direction.S:
                    y = isForward ? NegativePoint(y, _gridMaxHeight) : PositivePoint(y, _gridMaxHeight);
                    break;
                case Direction.W:
                    x = isForward ? NegativePoint(x, _gridMaxWidth) : PositivePoint(x, _gridMaxWidth);
                    break;
                default:
                    return coordinates;
            }

            if (IsObstacle(x, y))
                return null;

            coordinates.X = x;
            coordinates.Y = y;

            return coordinates;
        }

        private int PositivePoint(int point, int dimension)
        {
            return (point + 1) % dimension;
        }

        private int NegativePoint(int point, int dimension)
        {
            return point > 0 ? point - 1 : dimension - 1;
        }

        private bool IsObstacle(int x, int y)
        {
            if (_obstacles == null || _obstacles.ToList().Count == 0)
                return false;

           return _obstacles.Any(c => c.X == x && c.Y == y);
        }
    }
}
