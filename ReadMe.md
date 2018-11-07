# Pluto Rover Kata

This contains a Test driven working implementation of the Pluto Rover Kata.
The capabilities include:
	1. Movement forward and backward, one cell at a time
	2. Rotation 90 degrees left or right
	3. Wrapping of grid points thus if you are at cell 99 move forward you will end up on cell 0 and vice versa
	4. Obstacle detection. The rover will move up to the last cell before it encounters an obstacle and return its
	   current position as well as an additonal O to denote an obstacle has been found in the next cell.

Further Works
This kata was time limited thus there are further refactoring to be done for example,
the rover can accept its initial postion in the constructor. Interfaces may be needed to 
eliminate dependencies among the classes. 
There may also be a better way to implement the Direction class with each Direction being aware of its left and right counterpart.