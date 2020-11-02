using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Management : MonoBehaviour
{
    public Text gameStatus; 
    public bool playerIsInside = false;
    public bool close = false;

    // Update is called once per frame
    void Update()
    {
        if(GameObject.Find("Sphere").GetComponent<P1BallGlue>().objCounter == 3)
        {
            gameStatus.text = "Has ganado chaval";
        }
        if(GameObject.Find("Sphere").GetComponent<P2BallGlue>().objCounter2 == 3)
        {
            gameStatus.text = "Has ganado chaval";
        }
    }

    void winCondition()
    {
        if (GameObject.Find("Trigger").GetComponent<Trigger>().winner==true)
        {
            gameStatus.text = "";
        }
    }
}





