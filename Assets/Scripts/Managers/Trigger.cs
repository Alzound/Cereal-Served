using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public bool win = false;
    public string winner; 

    private void OnTriggerEnter(Collider other) //el avatar juega marco polo, toco a alguien
    {
        //This helps me out for knowing when the player enters the collider, so i can close the door behind him.
        if (other.tag == "Player1" || other.tag=="Player2")
        {
            win = true;
            winner = other.tag; 
      

            Debug.Log("Out");

        }
    }
}
