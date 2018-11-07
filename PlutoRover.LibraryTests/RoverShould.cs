using System.Collections.Generic;
using PlutoRover.Library;
using Xunit;
using Xunit.Abstractions;

namespace PlutoRover.LibraryTests
{
    public class RoverShould
    {
        private readonly ITestOutputHelper _output;
        private Grid _grid;

        public RoverShould(ITestOutputHelper output)
        {
            _output = output;
            _grid = new Grid();
        }

        [Theory]
        [InlineData("L", "0,0,W")]
        [InlineData("LL", "0,0,S")]
        [InlineData("LLL", "0,0,E")]
        [InlineData("LLLL", "0,0,N")]
        [InlineData("R", "0,0,E")]
        [InlineData("RR", "0,0,S")]
        [InlineData("RRR", "0,0,W")]
        [InlineData("RRRR", "0,0,N")]
        public void TurnAnyDirection(string command, string expected)
        {
            var rover = new Rover(_grid);
            var actual = rover.ExecuteCommand(command);

            Assert.True(expected == actual);
        }

        [Theory]
        [InlineData("FFF", "0,3,N")]
        [InlineData("RFF", "2,0,E")]
        [InlineData("RRFF", "0,98,S")]
        [InlineData("RRRFF", "98,0,W")]
        [InlineData("LF", "99,0,W")]
        [InlineData("LLF", "0,99,S")]
        [InlineData("LLLF", "1,0,E")]
        [InlineData("LLLLFF", "0,2,N")]
        [InlineData("FRF", "1,1,E")]
        [InlineData("BRF", "1,99,E")]
        [InlineData("FLF", "99,1,W")]
        [InlineData("BLF", "99,99,W")]
        public void MoveAnyDirectionWithWrapping(string command, string expected)
        {
            var rover = new Rover(_grid);
            var actual = rover.ExecuteCommand(command);

            _output.WriteLine(actual);
            Assert.True(expected == actual);
        }

        [Theory]
        [InlineData("FFRFF", "1,2,E,O")]
        [InlineData("BBBLFFF", "99,97,W,O")]
        public void StopBeforeObstacles(string command, string expected)
        {
            var obstacles = new List<Coordinate>
            {
                new Coordinate(2, 2),
                new Coordinate(98, 97)
            };
            _grid = new Grid(obstacles);

            var rover = new Rover(_grid);
            var actual = rover.ExecuteCommand(command);

            Assert.True(expected == actual);
        }

    }
}
