using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orbits : MonoBehaviour {

    public float xPos;       //x position of the planet
    public float yPos=0;     //y position of the planet
    public float zPos;       //z position of the planet

    public float increment;     //used to increase the angle value
    public float speed;         //speed of 
    public float majorAxis;     //major axis of the planet
    public float minorAxis;     //minor axis of the planet
    public float angle;         //orbit inclination angle

    public float motherPlanetX;  //x position of the mother planet
    public float motherPlanetY;  //y position of the mother planet
    public float motherPlanetZ;  //z position of the mother planet
    Vector3 movement;
	// Use this for initialization

	void Start ()
    { 
        
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void plotOrbit()
    {
        yPos= inclination(xPos, yPos, motherPlanetX, motherPlanetY, angle); //calculate the Y position using the slope equation

        if (increment <= 360)
        {
            //plot the orbit
            increment = increment + speed; 
            xPos = motherPlanetX + majorAxis * Mathf.Cos(increment);
            zPos = motherPlanetZ + minorAxis * Mathf.Sin(increment);
        }
        else
        {
            increment = 0.0f;
            xPos = 0.0f;
            yPos = 0.0f;
        }

        //transform the position of the planet
        transform.position = new Vector3(xPos,yPos,zPos);

    }

    //calculate the y position using the slope equation
    public float inclination(float x,float y, float x1,float y1, float slope)
    {
        y = y1 + slope * (x - x1);
        return y;
    }
}
