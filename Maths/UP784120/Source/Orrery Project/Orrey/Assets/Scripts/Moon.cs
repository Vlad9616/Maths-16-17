using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moon : MonoBehaviour
{

    public GameObject motherPlanet; //parent planet
    public Earth motherScript;      // //get access to mother planet's script
    Vector3 position;

    void Start ()
    {
  
        motherPlanet = GameObject.Find("Earth"); //fint parent planet
        motherScript = motherPlanet.GetComponent<Earth>();// get script

        //set the centre of the orbit to parent planet coordinates
        GetComponent<Orbits>().motherPlanetX = motherScript.GetComponent<Orbits>().xPos;
        GetComponent<Orbits>().motherPlanetY = motherScript.GetComponent<Orbits>().yPos;
        GetComponent<Orbits>().motherPlanetZ = motherScript.GetComponent<Orbits>().zPos;

        //initialize orbit 
        GetComponent<Orbits>().majorAxis = 1.0f;
        GetComponent<Orbits>().minorAxis = 1.0f;
        GetComponent<Orbits>().speed = 0.1f;
        GetComponent<Orbits>().angle = 0.1f;
     
      //  GetComponent<DrawLine>().xRadius = motherScript.GetComponent<Orbits>().majorAxis;
      //  GetComponent<DrawLine>().zRadius = motherScript.GetComponent<Orbits>().minorAxis;
        
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        //update the x,y,z coordinates  of the center of the orbit
        GetComponent<Orbits>().motherPlanetX = motherScript.GetComponent<Orbits>().xPos;
        GetComponent<Orbits>().motherPlanetY = motherScript.GetComponent<Orbits>().yPos;
        GetComponent<Orbits>().motherPlanetZ = motherScript.GetComponent<Orbits>().zPos;
        GetComponent<Orbits>().plotOrbit();

        //set parameters in order to draw the orbit
        GetComponent<DrawLine>().centerX = GetComponent<Orbits>().motherPlanetX;
        GetComponent<DrawLine>().centerZ = GetComponent<Orbits>().motherPlanetZ;
        GetComponent<DrawLine>().centreY = GetComponent<Orbits>().motherPlanetY;
        GetComponent<DrawLine>().xRadius = GetComponent<Orbits>().majorAxis;
        GetComponent<DrawLine>().zRadius = GetComponent<Orbits>().minorAxis;
        GetComponent<DrawLine>().slope = GetComponent<Orbits>().angle;
        GetComponent<DrawLine>().Draw();

        //save the new position of the planet
        position.x = GetComponent<Orbits>().xPos;
        position.y = GetComponent<Orbits>().yPos;
        position.z = GetComponent<Orbits>().zPos;
        position = new Vector3(GetComponent<Orbits>().xPos, GetComponent<Orbits>().yPos, GetComponent<Orbits>().zPos);

        GetComponent<Mouse>().twoD = Camera.main.WorldToScreenPoint(position); //convert object's coordinates fro world space to view space
        GetComponent<Mouse>().inRange();    //test the distance between the object and the mouse point

    }

    void OnGUI()  //display the name of the planet if the mouse point intersects the object
    {
        if (GetComponent<Mouse>().intersection == true)
            GUI.Box(new Rect(GetComponent<Mouse>().twoD.x, Screen.height - GetComponent<Mouse>().twoD.y, 75, 50), "Moon");
    }

}
