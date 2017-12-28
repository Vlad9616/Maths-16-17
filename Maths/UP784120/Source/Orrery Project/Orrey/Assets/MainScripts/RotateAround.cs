using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAround : MonoBehaviour
{
    public float inc;
    Vector3 rotation;
    public float angle;
    Quaternion qz;
    Quaternion qy;
    Quaternion final;

	// Use this for initialization
	void Start ()
    {
        inc = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
        inc++;
        if (inc == 360.0f)
        {
            inc = 0;
        }
        qz = Quaternion.AngleAxis(angle, Vector3.forward);
        qy = Quaternion.AngleAxis(inc, Vector3.up);
        final = qz * qy;
        transform.rotation = final;
    }
}
