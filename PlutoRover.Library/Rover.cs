namespace PlutoRover.Library
{
    public class Rover : IRover
    {
        private IGridCell _cell;
        private IDirection _direction;
        private readonly IGrid _grid;

        public Rover(IGrid grid, IGridCell origin, IDirection direction)
        {
            _cell = origin;
            _direction = direction;
            _grid = grid;
        }

        public string Move(string command)
        {
            var nextGridCell = _cell;
            foreach (var c in command.ToCharArray())
            {
                if (c == 'F')
                    nextGridCell = _grid.GetPosition(_cell, _direction.DirectionPoint, true);
                if (c == 'B')
                    nextGridCell = _grid.GetPosition(_cell, _direction.DirectionPoint, false);
                if (c == 'L')
                    _direction.DirectionPoint = _direction.Left();
                if (c == 'R')
                    _direction.DirectionPoint = _direction.Right();

                if (nextGridCell != null)
                    _cell = nextGridCell;
                else
                    break;
            }

            var obstacleCode = nextGridCell != null && nextGridCell.IsObstructedAhead ? ",O" : "";
            return $"{_cell.Coordinate.X},{_cell.Coordinate.Y},{_direction.DirectionPoint}{obstacleCode}";
        }
    }
}
