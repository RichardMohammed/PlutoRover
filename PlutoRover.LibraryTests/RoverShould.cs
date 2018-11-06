using System;
using Xunit;

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
        [Fact]
        public void MoveNorth1Space()
        {

        }
    }
}
