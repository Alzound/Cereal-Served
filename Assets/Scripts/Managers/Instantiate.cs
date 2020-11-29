using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiate : MonoBehaviour
{
    public GameObject NeutralCereals;
 

    private void Update()
    {
        for (int i = 0; i < 100; i++)
        {

            Instantiate(NeutralCereals, transform.position, Quaternion.identity);
            
           
        }Destroy(this);
    }
}
