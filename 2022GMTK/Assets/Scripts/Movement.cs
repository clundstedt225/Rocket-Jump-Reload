using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //Vars & Properties
    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    public Vector3 moveDirection = Vector3.zero;
    public Vector3 jumpVelocity = Vector3.zero;
    private float airFriction = 0.5f;
    CharacterController controller;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //if (!GameUI.Instance.gameIsPaused)
        //{

            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            moveDirection = Vector3.ClampMagnitude(transform.TransformDirection(moveDirection), 1);

            if (controller.isGrounded)
            {
                moveDirection *= speed;
                
                //Jumping Logic
                if (Input.GetButtonDown("Jump"))
                {
                    jumpVelocity = moveDirection * airFriction;
                    jumpVelocity.y = jumpSpeed;
                }
                else
                {
                    jumpVelocity = Vector3.zero;
                }
            }
            else
            {
                moveDirection *= 8;
            }    

            //Apply movements and simulate gravity
            jumpVelocity.y -= gravity * Time.deltaTime;
            controller.Move((moveDirection + jumpVelocity) * Time.deltaTime);
        //}
    }
}
