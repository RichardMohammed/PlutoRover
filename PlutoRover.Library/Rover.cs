namespace PlutoRover.Library
{
    public class Rover : IRover
    {
        private ICoordinate _coordinates;
        private Direction _direction;
        private readonly IGrid _grid;

        public Rover(IGrid grid, ICoordinate origin)
        {
            _coordinates = origin;
            _direction = Direction.N;
            _grid = grid;
        }

        public string ExecuteCommand(string command)
        {
            var nextCoordinate = _coordinates;
            foreach (var c in command.ToCharArray())
            {
                if (c == 'F')
                    nextCoordinate = _grid.Move(_coordinates, _direction, true);
                if (c == 'B')
                    nextCoordinate = _grid.Move(_coordinates, _direction, false);
                if (c == 'L')
                    _direction = _direction.TurnLeft();
                if (c == 'R')
                    _direction = _direction.TurnRight();

                if (nextCoordinate != null)
                    _coordinates = nextCoordinate;
                else
                    break;
            }

            var obstacleCode = nextCoordinate == null ? ",O" : "";
            return $"{_coordinates.X},{_coordinates.Y},{_direction}{obstacleCode}";
        }
    }
}
