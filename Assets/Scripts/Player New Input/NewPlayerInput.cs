using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class NewPlayerInput : MonoBehaviour
{
    PlayerControls controls;
    Vector3 move;
    Vector3 movement;
    public Rigidbody rb;

    [SerializeField]
    private int playerIndex = 0; 

    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    void Awake()
    {
        controls = new PlayerControls();
        controls.Player.Movement.performed += ctx => move = ctx.ReadValue<Vector2>();
        controls.Player.Movement.canceled += ctx => move = Vector2.zero;
    }
    void Update()
    {
        movement = new Vector3(move.x, 0, move.y);

        //movement = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

    }
    void FixedUpdate()
    {
        moveCharacter(movement);
    }
    void moveCharacter(Vector3 direction)
    {
        rb.MovePosition((Vector3)transform.position + (direction * 5f * Time.deltaTime));
    }

    public int GetPlayerIndex()
    {
        return playerIndex; 
    }


    void OnEnable()
    {
        controls.Player.Enable();
    }
    void OnDisable()
    {
        controls.Player.Disable();
    }


}

