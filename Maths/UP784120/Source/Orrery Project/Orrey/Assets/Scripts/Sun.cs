using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : MonoBehaviour {

    Vector3 position = new Vector3(0, 0, 0);
	// Use this for initialization
	void Start ()
    {
        transform.position = position;
    }

    // Update is called once per frame
    void Update ()
    {
        GetComponent<Mouse>().twoD = Camera.current.WorldToScreenPoint(position);//convert object's coordinates fro world space to view space
        GetComponent<Mouse>().inRange();  //test the distance between the object and the mouse point
    }

    void OnGUI() //display the name of the planet if the mouse point intersects the object
    {
        if (GetComponent<Mouse>().intersection == true)
            GUI.Box(new Rect(GetComponent<Mouse>().twoD.x, Screen.height - GetComponent<Mouse>().twoD.y, 50, 50), "Sun");
    }
}
