using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    public float jumpForce;
    public float moveInput;
    private Rigidbody2D rb;
    private bool faceR = true;
    private bool isGrounded;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask WIG;

    private float jumpTimeCounter;
    public float jumpTime;
    private bool isJumping;

    private Animator anim;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
        //isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, WIG);
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, LayerMask.GetMask("LayerMain", "LayerBack", "Ground"));
        
        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
        LayerInteract();

        if (faceR == false && moveInput > 0)
        {
            Flip();
        }else if(faceR == true && moveInput <0)
        {
            Flip();
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded == true)
        {
            anim.SetTrigger("takeOff");
            isJumping = true;
            AudioSource audio = this.GetComponent<AudioSource>();
            audio.Play();
            jumpTimeCounter = jumpTime;
            rb.velocity = Vector2.up * jumpForce;
            
        }
        if (Input.GetKey(KeyCode.Space) && isJumping == true)
        {
            if(jumpTimeCounter > 0)
            {
                rb.velocity = Vector2.up * jumpForce;
                jumpTimeCounter -= Time.deltaTime;
            }
            else { isJumping = false; }
            
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            isJumping = false;
        }
        if (isGrounded == false)
        {
            anim.SetBool("isJumping", true);
        }
        else { anim.SetBool("isJumping", false); }

        if (moveInput == 0)
        {
            anim.SetBool("isRunning", false);
        }
        else
        {
            anim.SetBool("isRunning", true);
        }

    }

    void Flip()
    {
        faceR = !faceR;
        Vector3 Scalar = transform.localScale;
        Scalar.x *= -1;
        transform.localScale = Scalar;
    }
    void LayerInteract()
    {
        //Physics2D.IgnoreLayerCollision(14, 10, true);
        //Physics2D.IgnoreLayerCollision(14, 14, true);
        //Physics2D.IgnoreLayerCollision(10, 14, true);
        //Physics2D.IgnoreLayerCollision(10, 10, true);

        if (this.gameObject.layer.Equals(10))
        {
            Physics2D.IgnoreLayerCollision(10, 13, true);
            Physics2D.IgnoreLayerCollision(14, 12, false);
        }
        if (this.gameObject.layer.Equals(14))
        {
            Physics2D.IgnoreLayerCollision(10, 13, false);
            Physics2D.IgnoreLayerCollision(14, 12, true);
            
        }
    }

    public void FootStep()
    {
        AudioSource footStep = GameObject.Find("body").GetComponent<AudioSource>();
        footStep.Play();
    }
}
