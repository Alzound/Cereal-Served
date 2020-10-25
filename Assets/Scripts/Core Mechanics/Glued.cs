using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glued : MonoBehaviour
{

    Collider onColission;

    // Start is called before the first frame update
    void Start()
    {
        onColission = GetComponent<Collider>();
    }


    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "PlayerBall")
        {

            //make objet a child of the player
            gameObject.transform.parent = col.transform;
            //Is curious how if you enabled the colissions (after they glued) the object tends to stay in the place where the other object was.
            onColission.enabled = false;
            //set to be kinematic
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
            gameObject.GetComponent<Rigidbody>().useGravity = false;

        }

    }
}
