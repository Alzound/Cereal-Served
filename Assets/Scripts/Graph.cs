using UnityEngine;

public class Graph : MonoBehaviour
{

	public Transform initialCube;

    void Update()
    {

        Transform point = Instantiate(initialCube);
        point.localPosition = Vector3.right;
        Debug.Log("This is wrong too");

    }

}