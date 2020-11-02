using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;



public class Timer : MonoBehaviour
{
    public Text  timerTxt;
    private float startTime;
    public float t = 60;






    // Start is called before the first frame update
    void Start()
    {

        //This is the timer that i used in order for the player to know how much time he has.
        timerStart();

    }

    // Update is called once per frame
    void Update()
    {
        t = t - Time.deltaTime;

        if (Keyboard.current.rKey.isPressed)
        {
            Debug.Log("Super Hot");

            timerRestart();


        }
        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f2");
        timerTxt.text = minutes + ":" + seconds;



        timerLost();



    }


    public void timerStart()
    {
        //This didn't work because it wasn't taking the value of t, so i had to put it.
        t = 180 ;
        t = t - Time.deltaTime;
        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f2");
        timerTxt.text = minutes + ":" + seconds;

    }

    //In case the time runs out the game stops. 
    public void timerLost()
    {
        if (t <= 0)
        {
            timerTxt.text = "You lost :(  \n R-Restart. \n Tab-Quit.";
        }
        //Uff blessed thy lord, this line of code can access another script and retrieve it's value. 
        //PD: I love you, guy who or woman who created this. 
        if (GameObject.Find("PlayerBall").GetComponent<P1BallGlue>().objCounter >= 15)
        {
            timerTxt.text = "";
        }
        if (GameObject.Find("PlayerBall").GetComponent<P2BallGlue>().objCounter2 >= 15)
        {
            timerTxt.text = "";
        }
    }

    void timerRestart()
    {
        //This restablish the value of t. 
        //and restart's the game with the timmer as it was. 
        t = 60;
        t = t - Time.deltaTime;

    }

}

