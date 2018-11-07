namespace PlutoRover.Library
{
    public class Rover
    {
        public Coordinate Coordinates { get; set; }
        private string _direction = "N";
        public int GridMaxHeight { get; set; }
        public int GridMaxWidth { get; set; }

        public Rover()
        {
            Coordinates = new Coordinate(0, 0);
            GridMaxHeight = 100;
            GridMaxWidth = 100;
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
            var x = Coordinates.X;
            var y = Coordinates.Y;

            switch (_direction)
            {
                case "N":
                    y = y > 0 ? y - 1 : GridMaxHeight - 1;
                    break;
                case "E":
                    x = x > 0 ? x - 1 : GridMaxWidth - 1;
                    break;
                case "S":
                    y = (y + 1) % GridMaxHeight;
                    break;
                case "W":
                    x = (x + 1) % GridMaxWidth;
                    break;
                default:
                    return Coordinates;
            }

            return new Coordinate(x, y);
        }


        private Coordinate MoveForward()
        {
            var x = Coordinates.X;
            var y = Coordinates.Y;

            switch (_direction)
            {
                case "N":
                    y = (y + 1) % GridMaxHeight;
                    break;
                case "E":
                    x = (x + 1) % GridMaxWidth;
                    break;
                case "S":
                    y = y > 0 ? y - 1 : GridMaxHeight - 1;
                    break;
                case "W":
                    x = x > 0 ? x - 1 : GridMaxWidth - 1;
                    break;
                default:
                    return Coordinates;
            }

            return new Coordinate(x, y);
        }
    }
}
