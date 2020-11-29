using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsManager : MonoBehaviour
{

    public string controller;  // I store this in the Player class
    public string controller2;
    public GameObject p1;
    public GameObject p2; 

    private void Awake()
    {

        Wait(); 
    }


    //This is my player controller manager, so in theory when any of the players enter #2 or #0 the controller is activated and then they can move their character. 
    //In any other case the player is nule and doesnt move neither its affected by the enviroment. 

    // Update is called once per frame
    void Update()
    {

        ChooseController();
    }

    IEnumerator Wait()
    {
        yield return new WaitForSeconds(5);
        p1.SetActive(true);
        p2.SetActive(true); 
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
