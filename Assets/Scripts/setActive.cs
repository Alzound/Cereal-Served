using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class setActive : MonoBehaviour
{
    public GameObject jefe; 

    // Start is called before the first frame update
    void Awake()
    {
        jefe.gameObject.SetActive(false); 
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.A))
        {
            
            jefe.gameObject.SetActive(true);
        }
        
    }
}
