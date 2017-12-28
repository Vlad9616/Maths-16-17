using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class DrawLine : MonoBehaviour
{
    public LineRenderer line;

    public int segments = 360; //total number of segments
    public float angle = 1.0f;

    public float xRadius; //x radius (major axis)
    public float zRadius; //y radius (minor axis)

    public float xPosition; //x position of the line
    public float zPosition; //z position of the line
    public float yPosition=0; //y position of the line
    
    public float centerX; //x axis of point of origin
    public float centreY=0; //y axis of point of origin
    public float centerZ; //z axis of point of origin
    public float slope;  //orbital inclination
    //Vector3 inclination;


	// Use this for initialization
	void Start ()
    {
        line = gameObject.GetComponent<LineRenderer>();
        line.SetVertexCount(segments);
        //line.useWorldSpace = false;
    }
	
	// Update is called once per frame
	void Update ()
    {
       
    }

    //Source: Draw circle around game object to indicate radius. (2016) .Retrieved from: https://gamedev.stackexchange.com/questions/126427/draw-circle-around-gameobject-to-indicate-radius
    public void Draw()
    { 
         float angle = 20.0f;
        for (int i=0;i<(segments);i++)
        {
            line.startWidth = 0.1f;
            xPosition = centerX+Mathf.Sin(Mathf.Deg2Rad * angle) * xRadius;
            zPosition = centerZ+Mathf.Cos(Mathf.Deg2Rad * angle) * zRadius;
            yPosition = inc(xPosition, yPosition, centerX, centreY, slope);
            line.SetPosition(i, new Vector3(xPosition, yPosition, zPosition));
            angle += (360f / segments);
        }
    }

    //calculate the y position using the slope equation
    public float inc(float x, float y, float x1, float y1, float slope)
    {
        y = y1 + slope * (x - x1);
        return y;
    }
    ///
}
