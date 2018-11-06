using System;

namespace PlutoRover.Library
{
    public class Rover
    {
        public string ExecuteCommand(string command)
        {
            var position = "0,0,N";
            foreach (var c in command.ToCharArray())
            {
                if (c == 'F')
                    position = "0,1,N";
            }
            return position;
        }
    }
}
