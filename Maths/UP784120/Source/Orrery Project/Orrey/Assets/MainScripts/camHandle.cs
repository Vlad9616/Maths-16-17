using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camHandle : MonoBehaviour {

   public bool displayOrbits;
    Camera cameraOne;
    Camera cameraTwo;
    Camera cameraThree;
    Camera cameraFour;

    // Use this for initialization
    void Start()
    {
        displayOrbits = false;
        cameraOne = GameObject.Find("CameraOne").GetComponent<Camera>();
        cameraTwo = GameObject.Find("CameraTwo").GetComponent<Camera>();
        cameraThree = GameObject.Find("CameraThree").GetComponent<Camera>();
        cameraFour = GameObject.Find("CameraFour").GetComponent<Camera>();
        cameraOne.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            cameraOne.enabled = true;
            cameraTwo.enabled = false;
            cameraThree.enabled = false;
            cameraFour.enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            cameraOne.enabled = false;
            cameraTwo.enabled = true;
            cameraThree.enabled = false;
            cameraFour.enabled = false;
        }

        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            cameraOne.enabled = false;
            cameraTwo.enabled = false;
            cameraThree.enabled = true;
            cameraFour.enabled = false;
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            cameraOne.enabled = false;
            cameraTwo.enabled = false;
            cameraThree.enabled = false;
            cameraFour.enabled = true;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

       /*
        if (Input.GetKeyDown(KeyCode.D))
            {
                displayOrbits = true;
            }

       
        if (Input.GetKeyDown(KeyCode.F))
            {
                displayOrbits = false;
            }
        */
    }
}
