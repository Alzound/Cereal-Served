// Instantiates 10 copies of Prefab each 2 units apart from each other

using UnityEngine;
using System.Collections;

public class CreationofNeutrals : MonoBehaviour
{
    public Transform prefab;
    void Start()
    { 
        
        for (int i = 0; i < 5; i++)
        {
            Instantiate(prefab, new Vector2(.01f, .01f), Quaternion.identity);
        }
    }
}