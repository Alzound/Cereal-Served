using UnityEngine;
using UnityEngine.UI;

public class P2BallGlue : MonoBehaviour
{
    public int objCounter = 0;
    public float points = 0;
    private float highscore = 100;
    public float scale = .5f;
    public float dScale = .2f;



    void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.tag == "Neutral Cereal")
        {
            //All this proccess controls the counter of the objects, as well as the size of the player ball, with it making it bigger
            objCounter += col.contactCount;
            points = objCounter * highscore;
            scale = objCounter + dScale;
            gameObject.transform.localScale = new Vector3(gameObject.transform.localScale.x + dScale, gameObject.transform.localScale.y + dScale, gameObject.transform.localScale.z + dScale);

        }

    }

}
