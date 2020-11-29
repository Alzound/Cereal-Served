 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameStatus : MonoBehaviour
{
    public TextMeshProUGUI statusTxtP1;
    public TextMeshProUGUI statusTxtP2;
    public float  points1 = 0;
    public float points2 = 0;
    public string highscore1;
    public string highscore2;
   

    // Update is called once per frame
    void Update()
    {
        //The update of the canvas according to their respective Text. 
        PointStatus();
        statusTxtP1.text = "Points:" + highscore1 + "!";
        statusTxtP2.text = "Points:" + highscore2 + "!";
    }

    void PointStatus()
    {
        //This updates the highscore taking the values of the P# BallGlue of objects and their respective operation. 
        points1 = GameObject.Find("P1 Handler").GetComponent<P1BallGlue>().points; 
        points2 = GameObject.Find("P2 Handler").GetComponent<P2BallGlue>().points;
        highscore1 = points1.ToString();
        highscore2 = points2.ToString();
    }
}
