using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Security.Cryptography.X509Certificates;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class P2BallGlue : MonoBehaviour
{
    public int objCounter2 = 0;
    public float points2 = 0;
    private float highscore2 = 100;
    public float scale2 = .5f;
    public float dScale2 = .2f;
    public Animator anima;
    public Text wintxt;

    private InputManager inputManager;



    /*
    private void Start()
    {
        //This gets the animator component. 
        anima = GetComponent<Animator>();

    }
    */

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Neutral Cereal")
        {
            //All this proccess controls the counter of the objects, as well as the size of the player ball, with it making it bigger
            objCounter2 += col.contactCount;
            points2 = objCounter2 * highscore2;
            scale2 = objCounter2 + dScale2;
            gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x + dScale2, gameObject.transform.localScale.y + dScale2, gameObject.transform.localScale.z + dScale2);

            //In the case the player gets 15 objects the game will thank them, and then quit. 
            /* if (objCounter >= 15)
             {
                 wintxt.text = "Winner!! ";
                 Application.Quit();
             }
            */
        }

    }

}
