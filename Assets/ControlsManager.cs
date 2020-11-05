using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsManager : MonoBehaviour
{

    public string controller;  // I store this in the Player class
    public string controller2; 


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Start"))
        {
            controller = "A";
            Debug.Log(controller); 
        }
        else if (Input.GetButton("2Start"))
        {
            controller2 = "B";
            Debug.Log(controller2);
        }
    }
}
