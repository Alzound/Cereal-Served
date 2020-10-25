using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem; 

public class NewPlayerInput : MonoBehaviour
{
    public float speed = 5;
    private Vector2 movementInput; 

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector3(movementInput.x, 0, movementInput.y) * speed * Time.deltaTime);
    }

    public void OnMovement(InputAction.CallbackContext ctxt) => movementInput = ctxt.ReadValue<Vector2>();
}
