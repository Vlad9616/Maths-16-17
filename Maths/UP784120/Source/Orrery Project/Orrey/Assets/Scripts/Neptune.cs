using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Neptune : MonoBehaviour
{
    Vector3 position;
    void Start()
    {
        GetComponent<Orbits>().motherPlanetX = 0;
        GetComponent<Orbits>().motherPlanetY = 0;
        GetComponent<Orbits>().majorAxis = 18.0f;
        GetComponent<Orbits>().minorAxis = 16.0f;
        GetComponent<Orbits>().speed = 0.002f;
        transform.position = new Vector3(0, 0, 0);
        GetComponent<RotateAround>().angle = 28.32f;
    }

    // Update is called once per frame
    void Update()
    {
        position.x = GetComponent<Orbits>().xPos;
        position.y = GetComponent<Orbits>().yPos;
        position.z = GetComponent<Orbits>().zPos;

        position = new Vector3(GetComponent<Orbits>().xPos, GetComponent<Orbits>().yPos, GetComponent<Orbits>().zPos);
        GetComponent<Mouse>().twoD = Camera.current.WorldToScreenPoint(position);
        GetComponent<Mouse>().inRange();
        GetComponent<Orbits>().plotOrbit();

        GetComponent<DrawLine>().centerX = GetComponent<Orbits>().motherPlanetX;
        GetComponent<DrawLine>().centerZ = GetComponent<Orbits>().motherPlanetZ;
        GetComponent<DrawLine>().centreY = GetComponent<Orbits>().motherPlanetY;
        GetComponent<DrawLine>().xRadius = GetComponent<Orbits>().majorAxis;
        GetComponent<DrawLine>().zRadius = GetComponent<Orbits>().minorAxis;
        GetComponent<DrawLine>().slope = GetComponent<Orbits>().angle;
        GetComponent<DrawLine>().Draw();
    }

    void OnGUI()
    {
        if (GetComponent<Mouse>().intersection == true)
            GUI.Box(new Rect(GetComponent<Mouse>().twoD.x, Screen.height - GetComponent<Mouse>().twoD.y, 50, 50), "Neptune");
    }
}
