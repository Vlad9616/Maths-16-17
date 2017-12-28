The project was created using Unity 5.5.0f3 and Visual Studio 2015.
A built version of the project is also provided.

Key mapping: 	1,2,3,4 keys are used to change the camera
		Esc-Close Application
	
Files description:
The source code is located in the Assets folder:

MainScripts:
-camHandle.cs -not part of the requirement features. Used to create multiple cameras
-DrawLine.cs - contains the source code that draws the orbits + orbital inclination
-Mouse.cs    - contains 2d intersection test
-Orbits.cs   -contins the source code that plots the orbits + orbital inclination
-Rotate around -contains the source code used to roatate the planets around their axis
		+axial tilt

Scripts:
All the scripts that are presented in the "Scripts file" are scripts created in order to 
customize the behavior of each planet/moon. The world-view transformation (built-in) and 
the mouse point-object intersection test is done for every planet.
