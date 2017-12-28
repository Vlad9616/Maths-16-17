using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pluto : MonoBehaviour {

    Vector3 position;

    void Start()
    {
        //set the orbit's parameters
        GetComponent<Orbits>().motherPlanetX = 0;
        GetComponent<Orbits>().motherPlanetY = 0;
        GetComponent<Orbits>().majorAxis = 20.0f;
        GetComponent<Orbits>().minorAxis = 18.0f;
        GetComponent<Orbits>().speed = 0.001f;
        GetComponent<Orbits>().angle = 0.1f;
        transform.position = new Vector3(0, 0, 0);
        GetComponent<RotateAround>().angle = 57.47f;
    }

    // Update is called once per frame
    void Update()
    {
        //save the new position of the planet
        position.x = GetComponent<Orbits>().xPos;
        position.y = GetComponent<Orbits>().yPos;
        position.z = GetComponent<Orbits>().zPos;
        position = new Vector3(GetComponent<Orbits>().xPos, GetComponent<Orbits>().yPos, GetComponent<Orbits>().zPos);


        GetComponent<Mouse>().twoD = Camera.current.WorldToScreenPoint(position); //convert object's coordinates fro world space to view space
        GetComponent<Mouse>().inRange(); //test the distance between the object and the mouse point

        GetComponent<Orbits>().plotOrbit(); //move the planet

        //set parameters in order to draw the orbit
        GetComponent<DrawLine>().centerX = GetComponent<Orbits>().motherPlanetX;
        GetComponent<DrawLine>().centerZ = GetComponent<Orbits>().motherPlanetZ;
        GetComponent<DrawLine>().centreY = GetComponent<Orbits>().motherPlanetY;
        GetComponent<DrawLine>().xRadius = GetComponent<Orbits>().majorAxis;
        GetComponent<DrawLine>().zRadius = GetComponent<Orbits>().minorAxis;
        GetComponent<DrawLine>().slope = GetComponent<Orbits>().angle;
        GetComponent<DrawLine>().Draw();
    }

    void OnGUI() //display the name of the planet if the mouse point intersects the object
    {
        if (GetComponent<Mouse>().intersection == true)
            GUI.Box(new Rect(GetComponent<Mouse>().twoD.x, Screen.height - GetComponent<Mouse>().twoD.y, 50, 50), "Pluto");
    }
}
