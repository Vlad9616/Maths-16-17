using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
   public Vector3 mousePos;                 //mouse mosition
   public Vector2 twoD;                     //stores the object's view space coordinates
   public bool intersection = false;        //true if there is intersection, false if not


	// Use this for initialization
	void Start ()
    {
       
    }
	
	// Update is called once per frame
	void Update ()
    {
       mousePos = Input.mousePosition;
	}

    //calculate the distance between two points using the Pythagorean Theorem
    public float distance(float x, float y, float z, float w)
    {
        float result, e1, e2 = 0;
        e1 = (z - x) * (z - x);
        e2 = (w - y) * (w - y);
        result = Mathf.Sqrt(e1 + e2);
        return result;
    }

    //
    public void inRange()
    {
        //calculate the distance between the mouse point and the object
        if (distance(mousePos.x, mousePos.y, twoD.x, twoD.y) <= 10)
        {
            intersection = true;
        }
        else
            intersection = false;
    }

    
}
