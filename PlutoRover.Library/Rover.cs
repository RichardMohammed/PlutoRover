using System;
using System.ComponentModel;

namespace PlutoRover.Library
{
    public class Rover
    {
        public Coordinate Coordinates { get; set; }
        private string _direction = "N";

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
                    _direction = TurnLeft();
                if (c == 'R')
                    _direction = TurnRight();
            }

            return $"{Coordinates.X},{Coordinates.Y},{_direction}";
        }

        private string TurnRight()
        {
            switch (_direction)
            {
                case "N":
                    return "E";
                case "E":
                    return "S";
                case "S":
                    return "W";
                default:
                    return "N";
            }
        }

        private string TurnLeft()
        {
            switch (_direction)
            {
                case "N":
                    return "W";
                case "W":
                    return "S";
                case "S":
                    return "E";
                default:
                    return "N";
            }
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
