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

    [Header("Force")]

    public int force;
    public int obj;
    public float push;
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
        
        controller = "none";
       
    }

    // Update is called once per frame
    void Update()
    {
        
        controller = GameObject.Find("Player Manager").GetComponent<ControlsManager>().controller;
        if (controller != "none")
        {
            
            options(); 
            push = GameObject.Find("P2 Handler").GetComponent<P2BallGlue>().objCounter;
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
            controller = GameObject.Find("Player Manager").GetComponent<ControlsManager>().controller;
        }
       

    }

    private void OnCollisionEnter(Collision hit)
    {


        if(hit.gameObject.tag == "Player2")
        {

           

            if(push < 8)
            {
  
                punch = 100;
                transform.Translate(hxMovement * frame * -walkSpeed * punch, vVelocity * frame, hzMovement * frame * -walkSpeed * punch);
  

            }
            else if(push > 8 && push <= 16)
            {
              
                punch = 300;
                transform.Translate(hxMovement * frame * -walkSpeed * punch, vVelocity * frame, hzMovement * frame * -walkSpeed * punch);

            }
            else if(push > 16 )
            {
                punch = 500;
                transform.Translate(hxMovement * frame * -walkSpeed * punch, vVelocity * frame, hzMovement * frame * -walkSpeed * punch);


            }
        }
    }

    void options()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            Application.Quit(); 
        }
    }

}

