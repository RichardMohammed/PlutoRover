using System;

namespace PlutoRover.Library
{
    public class Rover
    {
        public Coordinate Coordinates { get; set; }
        private string direction = "N";

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
                if (c == 'B')
                    Coordinates = Reverse();
                if (c == 'L')
                    direction = TurnLeft();
                if (c == 'R')
                    direction = TurnRight();
            }

            return $"{Coordinates.X},{Coordinates.Y},{direction}";
        }

        private string TurnRight()
        {
            return "E";
        }

        private string TurnLeft()
        {
            return "W";
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
