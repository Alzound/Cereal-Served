using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public bool winner = false; 

    private void OnTriggerEnter(Collider other) //el avatar juega marco polo, toco a alguien
    {
        //This helps me out for knowing when the player enters the collider, so i can close the door behind him.
        if (other.tag == "Player" || other.tag=="Player2")
        {
            winner = true; 
            Application.Quit();

            Debug.Log("Out");

        }
    }
}
