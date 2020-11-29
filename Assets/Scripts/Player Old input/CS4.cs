using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS4 : MonoBehaviour
{
    [Header("Movement")]

    public float hxMovement;
    public float hzMovement;
    public float walkSpeed = 5.0f;
    public float frame;

    [Header("Force")]

    public int force;
    public int obj;
    public int push;
    public int punch;


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
        //As i was telling you in the controls manager this part is for the controller to have a value of "none", so untill the players press their 
        //Respective start buttons then it's switched to the Input Settings and their respective map of controls. 
        controller = "none";

    }

    // Update is called once per frame
    void Update()
    {
        //It keeps searching for the response to the players controller. 
        controller = GameObject.Find("Player Manager").GetComponent<ControlsManager>().controller2;
        //So the it enters and the controls respond, as well as the simulated physics. 
        if (controller != "none")
        {
            //This part of the code gives me the paramet of the P#BallGlue and then i convert this into the paramet for punch. 
            int objCounter = gameObject.transform.parent.GetComponentInChildren<P1BallGlue>().objCounter;
            push = objCounter; 
            hxMovement = Input.GetAxis(controller + "Horizontal");
            hzMovement = Input.GetAxis(controller + "Vertical");
            frame = Time.deltaTime;
            transform.Translate(hxMovement * frame * walkSpeed, vVelocity * frame, hzMovement * frame * walkSpeed);
            isGrounded = Physics.CheckSphere(groundCheck.position, checkRadius, ground);

            if (isGrounded)
            {
                vVelocity = 0f;
                transform.Translate(hxMovement * frame * walkSpeed, vVelocity * frame, hzMovement * frame * walkSpeed);
                gravity = 0f;


            }
            if (isGrounded == true && Input.GetButtonDown(controller + "Jump"))
            {
                isGrounded = false;
                gravity = 9.81f;
                vVelocity = jumpForce;
                transform.Translate(hxMovement * frame * walkSpeed, vVelocity * frame, hzMovement * frame * walkSpeed);

            }
            else
            {
                vVelocity -= (gravity * frame);
                transform.Translate(hxMovement * frame * walkSpeed, 0 * frame, hzMovement * frame * walkSpeed);

            }



        }
        else
        {
            //If its not the case it keeps searching. 
            controller = GameObject.Find("Player Manager").GetComponent<ControlsManager>().controller;
        }


    }

    private void OnCollisionEnter(Collision hit)
    {
        //This part of the code is for the reaction to the other player that it will have in the movement of this respective player.
        //It detects the other player.
        if (hit.gameObject.tag == "Player1")
        {
            //Push is determined by the number of objects the other player has in it's power 
            //And their respective "punch" wich in this case is just a simple translation of this player in the opposite direction. 

            if (push < 8)
            {

                punch = 100;
                transform.Translate(hxMovement * frame * -walkSpeed * punch, vVelocity * frame, hzMovement * frame * -walkSpeed * punch);


            }
            else if (push > 8 && push <= 16)
            {
 
                punch = 300;
                transform.Translate(hxMovement * frame * -walkSpeed * punch, vVelocity * frame, hzMovement * frame * -walkSpeed * punch);

            }
            else if (push > 16)
            {
                punch = 500;
                transform.Translate(hxMovement * frame * -walkSpeed * punch, vVelocity * frame, hzMovement * frame * -walkSpeed * punch);


            }
        }
    }

}

