# Pluto Rover Kata

This contains a Test driven working implementation of the Pluto Rover Kata.
The capabilities include:
	1. Movement forward and backward, one cell at a time
	2. Rotation 90 degrees left or right
	3. Wrapping of grid points thus if you are at cell 99 move forward you will end up on cell 0 and vice versa
	4. Obstacle detection. The rover will move up to the last cell before it encounters an obstacle and return its
	   current position as well as an additonal O to denote an obstacle has been found in the next cell.

