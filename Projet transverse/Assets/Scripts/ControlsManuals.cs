using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlsManuals : MonoBehaviour {

    private float speed = 5f;
    private float jumpForce = 7f;
    public LayerMask ground;
    public Rigidbody2D rb;
    private bool grounded;
    public Transform point1;
    public Transform point2;
    public Transform collidingstart, collidingend,headstart,headend;
    private bool canJump;
    private float timer=0f;
    private float maxTimer=0.1f;
    private bool stuckleft;
    private bool stuckright;

    //link with animator
    Animator animator;

	void Start () {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
            
	}

    void Update()
    {
        
        if (Input.GetButton("Left"))
        {
            if (!Raycast())
            {
                animator.SetBool("Moving", true);
                rb.velocity = new Vector2(-speed, rb.velocity.y);
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else
            {
                animator.SetBool("Moving", false);
                rb.velocity = new Vector2(0, rb.velocity.y);
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }
        else if (Input.GetButton("Right"))
        {
            if (!Raycast())
            {
                animator.SetBool("Moving", true);
                rb.velocity = new Vector2(speed, rb.velocity.y);
                transform.localScale = new Vector3(1, 1, 1);
            }
            else
            {
                animator.SetBool("Moving", false);
                rb.velocity = new Vector2(0, rb.velocity.y);
                transform.localScale = new Vector3(1, 1, 1);
            }
        }
        else
        {
            animator.SetBool("Moving", false);
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

        grounded = Physics2D.OverlapArea(point1.position, point2.position,ground);
        if(grounded && Input.GetButtonDown("Jump"))
        {
            timer = 0;
            canJump = true;
            rb.AddForce(new Vector2(0, jumpForce*3));

        }
        else if(canJump && Input.GetButton("Jump") && timer<maxTimer)
            {
            timer += Time.deltaTime;
            rb.AddForce(new Vector2(0, jumpForce));
        }
        else
        {
            canJump = false;
        }
        animator.SetBool("Ground", grounded);
    }
    private bool Raycast()
    {
        Debug.DrawLine(collidingstart.position, collidingend.position, Color.green);
        bool stuck = Physics2D.Linecast(collidingstart.position, collidingend.position, 1 << LayerMask.NameToLayer("Ground"));
        bool head = Physics2D.Linecast(headstart.position, headend.position, 1 << LayerMask.NameToLayer("Ground"));
        bool test;
        if (stuck == false && head == false)
            test = false;
        else
            test = true;
        return test;
    }
}
