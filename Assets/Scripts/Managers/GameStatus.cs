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
    public GameObject P1; 
   

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Entra...?"); 
        PointStatus();
        Debug.Log("Entra...");
        statusTxtP1.text = "Points:" + highscore1 + "!";
        statusTxtP2.text = "Points:" + highscore2 + "!";
        Debug.Log("Sale..."); 
    }

    void PointStatus()
    {
        Debug.Log("Si entra"); 
        points1 = GameObject.Find("P1 Handler").GetComponent<P1BallGlue>().points; 
        Debug.Log("I have the points"); 
        points2 = GameObject.Find("P2 Handler").GetComponent<P2BallGlue>().points;
        Debug.Log("I have the points second player");
        highscore1 = points1.ToString();
        highscore2 = points2.ToString();
    }
}
