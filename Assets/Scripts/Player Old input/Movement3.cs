using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement3 : MonoBehaviour
{
    [Header ("Movement")]

    public float hMovement;
    public float walkSpeed = 5f;
    public float frame;

    [Header ("Rotation")]

    public float rMovement;
    public float rotationRate = 100f;

    [Header ("Jump")]

    public float verticalVelocity;
    public float jumpForce = 15f;
    public float gravity = 9.81f;

    [Header("Is grounded")]

    public bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask ground; 



   
    // Update is called once per frame
    void Update()
    {
        frame = Time.deltaTime;


        //............Movement............//

        hMovement = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.forward * hMovement * walkSpeed * frame);

        //............Rotation............//

        rMovement = Input.GetAxis("Vertical");
        transform.Rotate(0, rMovement * rotationRate * frame, 0);

        isGrounded = Physics.CheckSphere(groundCheck.position, checkRadius, ground);

        if(isGrounded)
        {
            verticalVelocity = 0;
            transform.Translate(Vector3.forward * hMovement * walkSpeed * frame);
            transform.Rotate(0, rMovement * rotationRate * frame, 0);

                if(Input.GetButtonDown("Jump"))
                {
                    verticalVelocity = jumpForce;
                    transform.Translate(0, verticalVelocity * frame, hMovement * walkSpeed * frame);
                    transform.Rotate(0, rMovement * rotationRate * frame, 0);

                }
        }
        else 
        {
            verticalVelocity -= gravity * frame;
            transform.Translate(0, verticalVelocity * frame, hMovement * walkSpeed * frame);
        }
    }

    void onColissionEnter(Collision coll)
    {

    }

}

