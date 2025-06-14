using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Controller : MonoBehaviour
{
    public float movespeed = 5;
    public float runspeed = 10;
    public float jumpForce = 300;
    public Rigidbody2D rb;
    public Animator anim;
    public SpriteRenderer spriteRenderer;

    public GroundChecker groundChecker;
    public Player_Health health;


    
    void Start()
    {
       rb = GetComponent<Rigidbody2D>();
        health = GetComponent<Player_Health>();
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        
    }

   
    void Update()
    {
        if(health.isDead) return;
        float moveInput = Input.GetAxis("Horizontal");
        if(moveInput >= 0)
        {
            spriteRenderer.flipX = false;
        }
        else if(moveInput < 0)
        {
            spriteRenderer.flipX = true;
        }

        if(moveInput != 0)
        {
            anim.SetBool("IsRun", true);
        }
        else
        {
            anim.SetBool("IsRun", false);
        }
        //Debug.Log($"Input value: {moveInput}");

        if (Input.GetKey(KeyCode.LeftShift))
        {

            rb.velocity = new Vector2(moveInput * runspeed, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(moveInput * movespeed, rb.velocity.y);
        }

        



        if (Input.GetKeyDown(KeyCode.Space) && groundChecker.isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce);
            anim.SetTrigger("jumpTrigger");      
        }

        // Spadanie bez skoku do dead zone np itp
        if (rb.velocity.y < -0.1f)
        {
            anim.SetBool("IsFalling", true);
            anim.SetBool("IsJumping", false);
        }
        // siup spacja
        else if (rb.velocity.y > 0.1f)
        {
            anim.SetBool("IsJumping", true);
            anim.SetBool("IsFalling", false);
        }
        else
        {
            anim.SetBool("IsJumping", false);
            anim.SetBool("IsFalling", false);
        }

        if (groundChecker.isGrounded)
        {
            anim.SetBool("IsJumping", false);
            anim.SetBool("IsFalling", false);
        }
    }
}


