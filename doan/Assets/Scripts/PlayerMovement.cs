using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : Unit
{

    public CharacterController2D controller;
    public Animator animator;

    public float runSpeed = 40f;

    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;

    // * Input Controller - Command Pattern
    //public Unit unitControl;
    public KeyCode keyJump;
    public KeyCode keyFire;
    public KeyCode keySwapWeapon;

    private JumpCommand jumpCmd = new JumpCommand();
    //!private FireCommand fireCmd = new FireCommand();
    private SwapCommand swapCmd = new SwapCommand();

    void Awake()
    {

    }

    // Update is called once per frame
    void Update()
    {

        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));


        if (Input.GetKeyDown(keyJump))
        {
            jumpCmd.Execute(this);
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }


		// Swap
		if (Input.GetKeyDown(keySwapWeapon))
        {
            swapCmd.Execute(this);
        }

    }

    public override void Jump()
    {
        jump = true;
        animator.SetBool("IsJumping", true);
    }
    public override void SwapWeapon()
    {
        base.SwapWeapon();
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }

    public void OnCrouching(bool isCrouching)
    {
        animator.SetBool("IsCrouching", isCrouching);
    }

    void FixedUpdate()
    {
        // Move our character
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}
