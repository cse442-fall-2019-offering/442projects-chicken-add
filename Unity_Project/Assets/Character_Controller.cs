using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Character_Controller : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    private float moveInput;

    private Rigidbody2D rb;

    private bool facingRight = true;

    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;
    public Animator animator;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        moveInput = Input.GetAxis("Horizontal");
        //right arrow input = 1, left = -1
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        if(facingRight == false && moveInput > 0)
        {
            Flip();
        } else if(facingRight == true && moveInput < 0)
        {
            Flip();
        }
        animator.SetFloat("Speed", Math.Abs(moveInput * speed));
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W) && isGrounded == true)
        {
            rb.velocity = Vector2.up * jumpForce;
            animator.SetBool("IsJumping", true);
            animator.SetFloat("Height", groundCheck.position.y);
            
        }
        
       
    }
    //This function flips the orientation of the sprite, using this
    //before animation.
    void Flip()
    {
        facingRight = !facingRight;
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;

        //comment boi
    }

    public void OnLanding () {
      animator.SetBool("IsJumping", false);
    }
}
