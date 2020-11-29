using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine.SceneManagement; 
using UnityEngine;
using UnityEngine.UI;
using TMPro;



public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerTxtP1;
    public TextMeshProUGUI timerTxtP2;
    private float startTime;
    public float t = 60;
    public string winner;
    public int options = 0;
    public float points1;
    public float points2;
    public GameObject Trigger1;
    public GameObject Trigger2;
    public GameObject Trigger3;
    public GameObject Trigger4;
    public GameObject Points1;
    public GameObject Points2;






    // Start is called before the first frame update
    void Start()
    {
        winner = "";
        //This is the timer that i used in order for the player to know how much time he has.
        timerStart();

    }

    // Update is called once per frame
    void Update()
    {


        Looking();

        t = t - Time.deltaTime;

        if (Input.GetKey(KeyCode.R))
        {

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
        t = 180;
        t = t - Time.deltaTime;
        string minutes = ((int)t / 60).ToString();
        string seconds = (t % 60).ToString("f2");
        timerTxtP1.text = minutes + ":" + seconds;
        timerTxtP2.text = minutes + ":" + seconds;

    }

    //In case the time runs out the game stops. 
    public void timerLost()
    {

        if (t <= 0 || winner != "none")
        {



            if (winner == "Player1")
            {
                timerTxtP1.text = "You lost :(  \n R-Restart. \n Tab-Quit.";
                timerTxtP2.text = "You Win! :D  \n R-Restart. \n Tab-Quit.";
            }
            else if (winner == "Player2")
            {
                timerTxtP1.text = "You Win! :O  \n R-Restart. \n Tab-Quit.";
                timerTxtP2.text = "You lost :(  \n R-Restart. \n Tab-Quit.";
            }

            if (t <= 0)
            {
                points1 = Points1.GetComponent<P1BallGlue>().points;
                points2 = Points2.GetComponent<P2BallGlue>().points;
                if (points1 > points2)
                {
                    timerTxtP1.text = "You Win! :O  \n R-Restart. \n Tab-Quit.";
                    timerTxtP2.text = "You lost :(  \n R-Restart. \n Tab-Quit.";
                }
                if (points1 < points2)
                {
                    timerTxtP1.text = "You lost :(  \n R-Restart. \n Tab-Quit.";
                    timerTxtP2.text = "You Win! :D  \n R-Restart. \n Tab-Quit.";
                }
                if(points1 == points2)
                {
                    timerTxtP1.text = "WHATTT?!? YOU BOTH LOST?? \n R-Restart. \n Tab-Quit.";
                    timerTxtP2.text = "WHATTT?!? yOU BOTH LOST??  \n R-Restart. \n Tab-Quit.";
                }

            }
        }
    }

        void timerRestart()
        {
            if (Input.GetKeyDown(KeyCode.R))
            {

                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);


                //This restablish the value of t. 
                //and restart's the game with the timmer as it was. 
                t = 180;
                t = t - Time.deltaTime;
            }

        }

        void Looking()
        {

            if (winner == "" && options == 0)
            {

                winner = Trigger1.GetComponent<Trigger>().winner;
                options++;


            }
            if (winner == "" && options == 1)
            {

                winner = Trigger2.GetComponent<Trigger>().winner;
                options++;

            }
            if (winner == "" && options == 2)
            {

                winner = Trigger3.GetComponent<Trigger>().winner;
                options++;
            }
            if (winner == "" && options == 3)
            {

                winner = Trigger4.GetComponent<Trigger>().winner;

            }
            options = 0;
        }


    
    
}
               
                  
                   
                
             
            
        
    


