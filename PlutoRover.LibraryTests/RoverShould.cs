using PlutoRover.Library;
using Xunit;
using Xunit.Abstractions;

namespace PlutoRover.LibraryTests
{

    //- Implement commands that move the rover forward/backward(‘F’,’B’). The rover may
    //  only move forward/backward by one grid point, and must maintain the same heading.
    // - Implement commands that turn the rover left/right (‘L’,’R’). These commands make
    //  the rover spin 90 degrees left or right respectively, without moving from its current spot.
    // - Implement wrapping from one edge of the grid to another. (Pluto is a sphere after all)
    // - Implement obstacle detection before each move to a new square.
    //   If a given sequence of commands encounters an obstacle, the rover moves up to the last possible point and reports the obstacle

    public class RoverShould
    {
        private readonly ITestOutputHelper _output;
        public RoverShould(ITestOutputHelper output)
        {
            _output = output;
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
            var rover = new Rover( );
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
            var rover = new Rover();
            var actual = rover.ExecuteCommand(command);

            _output.WriteLine(actual);
            Assert.True(expected == actual);
        }

    }
}
