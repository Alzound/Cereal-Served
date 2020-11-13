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
        ChooseController();
    }


    void ChooseController()
    {
        if (Input.GetButton("Start"))
        {
            controller = "A";
      
        }
        else if (Input.GetButton("2Start"))
        {
            controller2 = "C";
     
        }
    }
}
