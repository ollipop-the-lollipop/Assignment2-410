# Assignment2-410
Readme

Ollie Goldstein: Get started, character movement, The environment, The camera, Audio, dot product

Aidan Hart: Ending the Game, Enemies parts 1 and 2, linear interpolation, particle effect

Dot product: I took the vector from our starting position (a vector3) and its magnitude, then in update calculated the current position (vector3) and its magnitude, did 
the dot product of the two vectors, multiplied the magnitudes, stored the arccos(dot product/magnitudes) to a temp variable, then transformed the radians to degrees, we 
now have the angle between the player’s starting and current position. Implemented in PlayerMovement

Linear interpolation: Made the Ghosts speed increase gradually after leaving the waypoint using linear interpolation, set speed to 0
as they hit the waypoint, this was implemented in the WaypointPatrol script.

Particle effect: smoke particle effect is always running, smoke in the bathtub and final hallway