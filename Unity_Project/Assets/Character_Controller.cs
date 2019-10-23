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
    private CapsuleCollider2D box;
    private CircleCollider2D cir;
    private bool facingRight = true;

    private bool isGrounded;
    public Transform groundCheck;
    private bool isCrouching = false;
    private bool standUp = false;
    public Transform crouchCheck;
    private bool crouch;
    public float checkRadius;
    public LayerMask whatIsGround;
    public Animator animator;

    public static GameMaster gm;


    void Start()
    {
        box = GetComponent<CapsuleCollider2D>();
        cir = GetComponent<CircleCollider2D>();
        rb = GetComponent<Rigidbody2D>();
        cir.enabled = false;
    }

    void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);
        crouch = Physics2D.OverlapCircle(crouchCheck.position, checkRadius, whatIsGround);
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
        //Debug.Log(isCrouching);
        //Debug.Log(crouch);
      if ((Input.GetKeyDown(KeyCode.DownArrow) || Input.GetKeyDown(KeyCode.S)) && isCrouching == false)
        {
            box.enabled = false;
            cir.enabled = true;
            isCrouching = true;
            //rb.velocity = new Vector2((moveInput * speed) / 2, rb.velocity.y);
        }
        else if ((Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S)) && (crouch == false))
        {
            box.enabled = true;
            cir.enabled = false;
            isCrouching = false;
        }
        if((Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S)) && (crouch == true))
        {
            standUp = true;
        }
        if (standUp && (crouch == false))
        {
            box.enabled = true;
            cir.enabled = false;
            standUp = false;
            isCrouching = false;
        }
        /*if ((Input.GetKeyUp(KeyCode.DownArrow) || Input.GetKeyUp(KeyCode.S)) && (crouch == false))
        {
            box.enabled = true;
            isCrouching = false;
        }*/



        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && isGrounded == true)
        {
           
            rb.velocity = Vector2.up * jumpForce;
            animator.SetBool("IsJumping", true);
            //animator.SetFloat("Height", groundCheck.position.y);
            
        }
      if ((!Input.GetKeyDown(KeyCode.UpArrow) && !Input.GetKeyDown(KeyCode.W)) && isGrounded == false)
      {
        animator.SetBool("IsJumping", true);
      }
      if ((!Input.GetKeyDown(KeyCode.UpArrow) && !Input.GetKeyDown(KeyCode.W)) && isGrounded == true) {
        animator.SetBool("IsJumping", false);
      }
      animator.SetBool("IsCrouching", isCrouching);



      
        
       
    }
    //This function flips the orientation of the sprite, using this
    //before animation.
    void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
        /*
        Vector3 Scaler = transform.localScale;
        Scaler.x *= -1;
        transform.localScale = Scaler;
        */
        //comment boi
    }

    

   }
