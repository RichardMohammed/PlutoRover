using System;

namespace PlutoRover.Library
{
    public class Rover
    {
        Coordinate _coordinates = new Coordinate(0, 0);
        public string ExecuteCommand(string command)
        {
            foreach (var c in command.ToCharArray())
            {
                if (c == 'F')
                    _coordinates = MoveForward();
            }

            return $"{_coordinates.X},{_coordinates.Y},N";
        }

        private Coordinate MoveForward()
        {
            return new Coordinate(_coordinates.X, _coordinates.Y + 1);
        }
    }
}
