using PlutoRover.Library;
using Xunit;
using Xunit.Abstractions;

namespace PlutoRover.LibraryTests
{

    //- Implement commands that move the rover forward/backward(�F�,�B�). The rover may
    //  only move forward/backward by one grid point, and must maintain the same heading.
    // - Implement commands that turn the rover left/right (�L�,�R�). These commands make
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
        [InlineData("F", "0,1,N")]
        [InlineData("FF", "0,2,N")]
        [InlineData("FFF", "0,3,N")]
        [InlineData("FFFF", "0,4,N")]
        public void MoveNorth(string command, string expected)
        {
            var rover = new Rover();
            var actual = rover.ExecuteCommand(command);

            Assert.True(expected == actual);
        }

        [Fact]
        public void MoveSouth()
        {
            var expected = "0,1,N";
            var rover = new Rover{Coordinates = new Coordinate(0, 2)};
            var actual = rover.ExecuteCommand("B");

            Assert.True(expected == actual);
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

        [Fact]
        public void WrapMovementReverse()
        {
            var expected = "0,99,N";
            var rover = new Rover();
            var actual = rover.ExecuteCommand("B");

            _output.WriteLine(actual);
            Assert.True(expected == actual);
        }

        [Fact]
        public void WrapMovementForward()
        {
            var expected = "0,0,N";
            var rover = new Rover {Coordinates = new Coordinate(0, 99)};
            var actual = rover.ExecuteCommand("F");

            _output.WriteLine(actual);
            Assert.True(expected == actual);
        }

    }
}
