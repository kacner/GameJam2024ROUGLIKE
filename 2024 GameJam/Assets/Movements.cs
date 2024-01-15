using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movements : MonoBehaviour
{
    public PlayerController controller;
    public float runSpeed = 40f;
    float horizontalMove = 0f;
    public bool jump = false;
    public bool crouch = false;
    private Rigidbody2D m_Rigidbody2D;
  //  public Animator animator;
   // public StunPike StunPikeReference;
    private bool Stunning;
    private bool CurrentlyAttacking;
    void Update()
    {
        //Stunning = StunPikeReference.stunning;
        //CurrentlyAttacking = StunPikeReference.IsCurrentlyAttacking;

        /*animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        animator.SetBool("Crouch", crouch);
        animator.SetBool("Stunning", Stunning);
        animator.SetBool("Attacking", CurrentlyAttacking);
        */
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        
        if (crouch)
        {
            horizontalMove = Input.GetAxisRaw("Horizontal") * 1;
        }
        if (Stunning)
        {
            horizontalMove = Input.GetAxisRaw("Horizontal") * 0.5f;
        }


        if (Input.GetKeyDown(KeyCode.W))
        {
            jump = true;
            
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            crouch = true;

        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            crouch = false;
        }
    }


    void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }

}
