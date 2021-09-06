using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public CharacterController2D controller;
    public Animator animator;

    private float runSpeed = 40f;

    float horizontalMove =0f;

    bool jump = false;
    bool crouch = false;

    void Update()
    {
        horizontalMove=Input.GetAxisRaw("Horizontal")*runSpeed;

        animator.SetFloat("speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("isJumping", true);
        }

        if(Input.GetKeyDown(KeyCode.Z))
        {
            crouch = true;
       }else if (Input.GetKeyUp(KeyCode.Z)) 
        {
            crouch = false;
        }
       
    }

   

    public void OnLanding()
    {
        animator.SetBool("isJumping", false);
    }

    public void OnCrouching(bool isCrouching)
    {
        animator.SetBool("IsCrouching", isCrouching);
    }

    void FixedUpdate()
    {

        controller.Move(horizontalMove*Time.fixedDeltaTime,crouch, jump);
        jump = false;

    }
}
