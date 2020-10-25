using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTransform : MonoBehaviour
{
    [Header("Movement")]

    public float hxMovement; 
    public float hzMovement;
    public float walkSpeed = 5.0f;
    public float frame;

    [Header("Jump")]

    public float vVelocity;
    public float jumpForce = 15.0f;
    public float gravity = 9.81f;

    [Header("Ground")]

    public bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask ground; 


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        hxMovement = Input.GetAxis("Horizontal");
        hzMovement = Input.GetAxis("Vertical");
        frame = Time.deltaTime;
        transform.Translate(hxMovement * frame * walkSpeed, vVelocity * frame , hzMovement * frame * walkSpeed);
        isGrounded = Physics.CheckSphere(groundCheck.position, checkRadius, ground);

        if(isGrounded)
        {
            vVelocity = 0;
            transform.Translate(hxMovement * frame * walkSpeed, vVelocity * frame, hzMovement * frame * walkSpeed);

        }if (Input.GetButtonDown("Jump"))
        {
            vVelocity = jumpForce;
            transform.Translate(hxMovement * frame * walkSpeed, vVelocity * frame, hzMovement * frame * walkSpeed);

        }
        else
        {
            vVelocity -= (gravity * frame);
            transform.Translate(hxMovement * frame * walkSpeed, vVelocity * frame, hzMovement * frame * walkSpeed);
        }

    }
}
