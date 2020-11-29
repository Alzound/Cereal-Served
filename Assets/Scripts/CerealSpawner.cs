using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CerealSpawner : MonoBehaviour
{
    ObjectPooler objectPooler;

    private void Start()
    {
        objectPooler = ObjectPooler.Instance;
  
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        objectPooler.SpawnFromPool("Neutral Cereal", transform.position, Quaternion.identity);
        
    }
    
}
