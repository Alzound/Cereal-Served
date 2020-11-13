using UnityEngine;
using UnityEngine.UI;

public class P1BallGlue : MonoBehaviour
{
    public int objCounter = 0;
    public float points = 0;
    private float highscore = 100; 
    public float scale = .5f;
    public float dScale = .2f;
    public int obj;
    public float walkspeed; 
    public Animator anima;
    public Text wintxt;
    Collider onColission;
    public Rigidbody2D rb;


    private void Start()
    {
        //This gets the animator component. 
        anima = GetComponent<Animator>();
        onColission = GetComponent<Collider>();
        rb = GetComponent<Rigidbody2D>();
    }
    

    void OnCollisionEnter(Collision col)
    {
        Debug.Log("1");
        if (col.gameObject.tag == "Neutral Cereal")
        {
            //All this proccess controls the counter of the objects, as well as the size of the player ball, with it making it bigger
            objCounter += col.contactCount;
            points = objCounter * highscore; 
            scale = objCounter + dScale;
            gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x + dScale, gameObject.transform.localScale.y + dScale, gameObject.transform.localScale.z + dScale);

        }
        else 
        if (col.gameObject.tag == "Player2")
        {
            Debug.Log("Entra2");
            rb.AddForce(transform.up * 20.5f);

        }

    }

    

}
