using System;

namespace PlutoRover.Library
{
    public class Rover
    {
        public Coordinate Coordinates { get; set; } 

        public Rover()
        {
            Coordinates = new Coordinate(0, 0);
        }

        public string ExecuteCommand(string command)
        {
            foreach (var c in command.ToCharArray())
            {
                if (c == 'F')
                    Coordinates = MoveForward();
                else if (c == 'B')
                    Coordinates = Reverse();
            }

            return $"{Coordinates.X},{Coordinates.Y},N";
        }

        private Coordinate Reverse()
        {
            return new Coordinate(Coordinates.X, Coordinates.Y - 1);
        }

        private Coordinate MoveForward()
        {
            return new Coordinate(Coordinates.X, Coordinates.Y + 1);
        }
    }
}
