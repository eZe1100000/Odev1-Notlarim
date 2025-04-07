using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class characterController2 : MonoBehaviour
{

    public  float speed;
    private bool moving;
    private bool jump;
    private bool grounded = true;
    private float moveDireciton;
    public float jumpForce;
    private Rigidbody2D rb2D;
    private Animator animator;
    private SpriteRenderer spriteRenderer;


    private void Awake()
    {
        animator = GetComponent<Animator>();
    }


    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    private void FixedUpdate()
    {
        if( rb2D.velocity != Vector2.zero)
        {
            moving = true;
        }
        else
        {
            moving = false;
        }

        rb2D.velocity = new Vector2(speed * moveDireciton , rb2D.velocity.y);

        if (jump == true)
        {
            rb2D.velocity = new Vector2(rb2D.velocity.x, jumpForce);
            jump = false;
            animator.SetTrigger("jump");
            animator.SetBool("grounded" , false);

        }
    }



    // Update is called once per frame
    void Update()
    {
        if ((grounded == true) && Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D))
        {
            if (Input.GetKey(KeyCode.A))
            {
                moveDireciton = -1.0f;
                spriteRenderer.flipX = true;
                animator.SetFloat("speedUnity" , speed);
            } else if (Input.GetKey(KeyCode.D))
            {
                moveDireciton = 1.0f;
                spriteRenderer.flipX = false;
                animator.SetFloat("speedUnity", speed);

            }
        }else if (grounded == true)
        {
            moveDireciton = 0.0f;
            animator.SetFloat("speedUnity", speed);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            jump = true;
            grounded = false;
            animator.SetTrigger("jump");
        }
        
    }




    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("zemin"))
        {
            animator.SetBool("grounded", true);
            grounded = true;
        }
    }
}
