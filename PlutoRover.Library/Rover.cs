using System;
using System.Collections.Generic;

namespace PlutoRover.Library
{
    public class Rover : IRover
    {
        private IGridCell _cell;
        private readonly IDirection _direction;
        private readonly IGrid _grid;
        private readonly Dictionary<char, Func<CardinalDirection>> _turn = new Dictionary<char, Func<CardinalDirection>>();
        private readonly Dictionary<char, Func<IGridCell>> _move = new Dictionary<char, Func<IGridCell>>();

        public Rover(IGrid grid, IGridCell origin, IDirection direction)
        {
            _cell = origin;
            _direction = direction;
            _grid = grid;

            _turn.Add('L', _direction.Left);
            _turn.Add('R', _direction.Right);
            _move.Add('F', Forward);
            _move.Add('B', Backward);
        }

        private IGridCell Forward()
        {
            return _grid.GetPosition(_cell.Coordinate, _direction.DirectionPoint, true);
        }

        private IGridCell Backward()
        {
            return _grid.GetPosition(_cell.Coordinate, _direction.DirectionPoint, false);
        }

        public string Move(string command)
        {
            var nextGridCell = _cell;
            foreach (var c in command.ToCharArray())
            {
                _direction.DirectionPoint = _turn.ContainsKey(c) ? _turn[c]() : _direction.DirectionPoint;
                nextGridCell = _move.ContainsKey(c) ? _move[c]() : nextGridCell;

                if (nextGridCell == null || nextGridCell.IsObstructedAhead)
                    break;

                _cell = nextGridCell;
            }

            var obstacleCode = nextGridCell != null && nextGridCell.IsObstructedAhead ? ",O" : "";
            return $"{_cell.Coordinate.X},{_cell.Coordinate.Y},{_direction.DirectionPoint}{obstacleCode}";
        }
    }
}
