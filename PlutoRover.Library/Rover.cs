namespace PlutoRover.Library
{
    public class Rover
    {
        private Coordinate _coordinates;
        private Direction _direction;
        private readonly Grid _grid;

        public Rover()
        {
            _coordinates = new Coordinate(0, 0);
            _direction = Direction.N;
            _grid = new Grid();
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
