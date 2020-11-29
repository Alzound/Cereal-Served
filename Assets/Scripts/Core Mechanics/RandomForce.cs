using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomForce : MonoBehaviour
{
    //So this is actually the script for the Neutral Cereals to Spawn. Thanks to Brakeys. 
    public float forceup = .2f;
    public float sideforce = .02f; 

    // Start is called before the first frame update
    void Start()
    {
        //As i aknowledge it this part of the script gives us a range between this values to just deploy the Neutral Cereals according to this specification. 
        float xForce = Random.Range(-sideforce, sideforce);
        float yForce = Random.Range(forceup/2, forceup);
        float zForce = Random.Range(-sideforce, sideforce);

        Vector3 force = new Vector3(xForce,yForce,zForce);

        //And this just add force in that predilect direction. 
        GetComponent<Rigidbody>().velocity = force;
    }

}
