using System.Collections.Generic;
using PlutoRover.Library;
using Xunit;
using Xunit.Abstractions;

namespace PlutoRover.LibraryTests
{
    public class RoverShould
    {
        private readonly ITestOutputHelper _output;
        private readonly IRover _rover;

        public RoverShould(ITestOutputHelper output)
        {
            _output = output;
            IEnumerable<ICoordinate> obstacles = new List<ICoordinate>
            {
                new Coordinate(2, 2),
                new Coordinate(98, 97)
            };
            IGrid grid = new Grid(obstacles);
            ICoordinate origin = new Coordinate(0, 0);
            IGridCell cell = new GridCell {Coordinate = origin, IsObstructedAhead = false};
            IDirection direction = new Direction {DirectionPoint = CardinalDirection.N};
            _rover = new Rover(grid, cell, direction);
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
            var actual = _rover.Move(command);
            _output.WriteLine(expected);
            _output.WriteLine(actual);

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
        public void MoveAnyDirectionWithWrappingFrom0X0(string command, string expected)
        {
            var actual = _rover.Move(command);

            _output.WriteLine(actual);
            Assert.True(expected == actual);
        }

        [Theory]
        [InlineData(0, 99, CardinalDirection.N, "F", "0,0,N")]
        [InlineData(0, 99, CardinalDirection.S, "B", "0,0,S")]
        [InlineData(99, 0, CardinalDirection.E, "F", "0,0,E")]
        [InlineData(99, 0, CardinalDirection.W, "B", "0,0,W")]
        public void MoveWithWrappingFromEdges(int x, int y, CardinalDirection directionPoint, string command, string expected)
        {
            IGrid grid = new Grid();
            ICoordinate origin = new Coordinate(x, y);
            IGridCell cell = new GridCell { Coordinate = origin, IsObstructedAhead = false };
            IDirection direction = new Direction { DirectionPoint = directionPoint };
            var rover = new Rover(grid, cell, direction);

            var actual = rover.Move(command);

            _output.WriteLine(actual);
            Assert.True(expected == actual);
        }

        [Theory]
        [InlineData("FFRFFFFFF", "1,2,E,O")]
        [InlineData("BBBLFFF", "99,97,W,O")]
        public void StopBeforeObstacles(string command, string expected)
        {
            var actual = _rover.Move(command);

            _output.WriteLine(actual);
            Assert.True(expected == actual);
        }

    }
}
