using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 500f;
    public int jumpCnt = 0;
    private bool isGrounded = false;
    private bool isDead = false;
    public float moveForece = 500f;



    private Rigidbody2D rb;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (isDead)
        {
            return;
        }
        jump();
        
    }

    private void jump()
    {
        if (Input.GetMouseButtonDown(0) && jumpCnt < 2)
        {
            jumpCnt++;
            rb.velocity = Vector2.zero;
            rb.AddForce(new Vector2(0, jumpForce));

            animator.SetBool("Grounded", true);
        }
        else if (Input.GetMouseButtonUp(0) && rb.velocity.y > 0)
        {
            rb.velocity = rb.velocity * 0.5f;
        }
    }

    private void Move()
    {
        rb.velocity = new Vector2(moveForece, rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision) // 충돌 처리
    {
        if(collision.contacts[0].normal.y>0.7f)
        {
            isGrounded = true;
            jumpCnt = 0;
            animator.SetBool("Grounded", false);
        }
    }
}
