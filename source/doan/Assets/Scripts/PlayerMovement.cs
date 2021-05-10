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
    private FireCommand fireCmd = new FireCommand();
    private SwapCommand swapCmd = new SwapCommand();

    public WeaponStrategy weapon;
    public List<WeaponStrategy> allWeapon;
    

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

        if (Input.GetKeyDown(keyFire))
        {
            fireCmd.Execute(this);
        }


        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            // * Heal
            controller.currenthp += 10;
            if (controller.currenthp > controller.hp)
            {
                controller.currenthp = controller.hp;
            }
            VFXFactory.getInstance().getVFX(EnumVFXAbility.Heal).Process();
        }

    }

    public override void Jump()
    {
        jump = true;
        animator.SetBool("IsJumping", true);
    }
    public override void SwapWeapon()
    {
        if (this.weapon.GetInstanceID() == this.allWeapon[this.allWeapon.Count - 1].GetInstanceID())
        {
            this.weapon.enabled = false;
            this.weapon = this.allWeapon[0];
            this.weapon.enabled = true;

            return;
        }
        //base.SwapWeapon();
        for (int i = 0; i < this.allWeapon.Count; i++)
        {

            if (this.allWeapon[i].GetInstanceID() == this.weapon.GetInstanceID())
            {
                this.weapon.enabled = false;
                this.weapon = this.allWeapon[i + 1];
                this.weapon.enabled = true;

                break;
            }
        }
    }
    public override void Fire()
    {
        //Debug.Log("fire");
        this.weapon.Shoot();
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
