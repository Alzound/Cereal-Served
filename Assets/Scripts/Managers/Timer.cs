using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class Timer : MonoBehaviour
{
    public TextMeshProUGUI  timerTxtP1;
    public TextMeshProUGUI timerTxtP2;
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

        if (Input.GetKey(KeyCode.R))
        {
            Debug.Log("Super Hot");

            timerRestart();


        }
        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f2");
        timerTxtP1.text = minutes + ":" + seconds;
        timerTxtP2.text = minutes + ":" + seconds;



        timerLost();



    }


    public void timerStart()
    {
        //This didn't work because it wasn't taking the value of t, so i had to put it.
        t = 180 ;
        t = t - Time.deltaTime;
        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f2");
        timerTxtP1.text = minutes + ":" + seconds;
        timerTxtP2.text = minutes + ":" + seconds;

    }

    //In case the time runs out the game stops. 
    public void timerLost()
    {
        if (t <= 0)
        {
            timerTxtP1.text = "You lost :(  \n R-Restart. \n Tab-Quit.";
            timerTxtP2.text = "You lost :(  \n R-Restart. \n Tab-Quit.";
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

