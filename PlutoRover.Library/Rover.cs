namespace PlutoRover.Library
{
    public class Rover
    {
        public Coordinate Coordinates { get; set; }
        private Direction _direction;
        private Grid _grid;

        public Rover()
        {
            Coordinates = new Coordinate(0, 0);
            _direction = Direction.N;
            _grid = new Grid();
        }

        public string ExecuteCommand(string command)
        {
            foreach (var c in command.ToCharArray())
            {
                if (c == 'F')
                    Coordinates = _grid.MoveForward(Coordinates, _direction);
                if (c == 'B')
                    Coordinates = _grid.Reverse(Coordinates, _direction);
                if (c == 'L')
                    _direction = _direction.TurnLeft();
                if (c == 'R')
                    _direction = _direction.TurnRight();
            }

            return $"{Coordinates.X},{Coordinates.Y},{_direction}";
        }
    }
}
