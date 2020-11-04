using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS4 : MonoBehaviour
{
    [Header("Movement")]

    public float hcxMovement;
    public float hczMovement;
    public float walkSpeed = 5.0f;
    public float frame;

    [Header("Force")]

    public int force;
    public int obj;

    [Header("Control")]

    public string controller;

    [Header("Jump")]

    public float vVelocity = 0f;
    public float jumpForce = 10.0f;
    public float gravity = 9.81f;

    [Header("Ground")]

    public bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask ground;


    // Start is called before the first frame update
    void Start()
    {
        controller = "none"; 
    }

    // Update is called once per frame
    void Update()
    {
        controller = GameObject.Find("Player Manager").GetComponent<ControlsManager>().controller2;
        hcxMovement = Input.GetAxis(controller + "Horizontal");
        Debug.Log(hcxMovement);
        Debug.Log(hczMovement);
        hczMovement = Input.GetAxis(controller + "Vertical");
        frame = Time.deltaTime;
        transform.Translate(hcxMovement * frame * walkSpeed, vVelocity * frame, hczMovement * frame * walkSpeed);
        isGrounded = Physics.CheckSphere(groundCheck.position, checkRadius, ground);

        if (isGrounded)
        {
            vVelocity = 0f;
            transform.Translate(hcxMovement * frame * walkSpeed, vVelocity * frame, hczMovement * frame * walkSpeed);
            gravity = 0f;


        }
        if (isGrounded == true && Input.GetButtonDown(controller + "X button"))
        {
            isGrounded = false;
            gravity = 9.81f;
            vVelocity = jumpForce;
            transform.Translate(hcxMovement * frame * walkSpeed, vVelocity * frame, hczMovement * frame * walkSpeed);

        }
        else
        {
            vVelocity -= (gravity * frame);
            transform.Translate(hcxMovement * frame * walkSpeed, 0 * frame, hczMovement * frame * walkSpeed);

        }

    }

    void OnColiisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Player1")
        {
            obj = GameObject.Find("PlayerBall").GetComponent<P2BallGlue>().objCounter;
            hcxMovement += (hcxMovement + obj);
            hczMovement += (hczMovement + obj);

        }
    }

}
