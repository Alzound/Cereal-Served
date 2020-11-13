using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerIndex
{
    ONE,
    TWO,
    THREE,
    FOUR,
    FIVE,
    SIX,
    SEVEN,
    EIGHT
}

public class PlayerIndexManager : MonoBehaviour
{
    public PlayerIndex playerIndex = PlayerIndex.ONE;

    public void TouchedOtherPlayer(string player)
    {
        //manejamos el evento
        Debug.Log("Mi Trigger, me avisó que entré en contacto con " + player + ", siendo yo el " + playerIndex);
        GetComponent<Rigidbody>().AddForce(Vector3.forward * Mathf.PI);
    }

    public void TouchedOtherPlayer(PlayerIndex player)
    {
        //manejamos el evento
        Debug.Log("Mi Trigger, me avisó que entré en contacto con " + player + ", siendo yo el " + playerIndex);
        GetComponent<Rigidbody>().AddForce(Vector3.forward * Mathf.PI);
    }
}
