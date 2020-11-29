using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnMeshSimulation : MonoBehaviour
{
    public float speed = Mathf.PI;

    public float amplitude = 0.5f;
    public float phi = 1.5f;
    public float dephase = 2.35f;


    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.tag == "Milk")
        {
            Debug.Log("Ha entrado al stay");
            Vector3 direction = Vector3.right; //la norma del vector es 1, normalizado

            transform.Translate((speed * direction * Time.deltaTime));
            //nos movemos Pi unidades de unity,
            //a la derecha
            //por segundo


            float positionY = amplitude * Mathf.Sin(phi * transform.position.x + dephase);

            transform.position = new Vector3(
                transform.position.x, //redundante
                positionY, //lo que calculamos de la función senoidal
                transform.position.z //redundante
            );
        }
    }
}
    

  


