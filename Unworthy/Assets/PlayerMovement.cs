using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerMovement : MonoBehaviour
{
    // Start() variables
    private Rigidbody2D rb;
    private Animator anim;
    private Collider2D coll;

    private BoxCollider2D collide2D;

    // Finite State Machine
    private enum State { idle, running, jumping, falling, crouch };
    private State state = State.idle;

    // Inspector variables
    [SerializeField] private LayerMask ground;
    [SerializeField] private LayerMask item;
    [SerializeField] private float speed = 5f;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private float HurtForce = 10f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
        collide2D = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();

        AnimationState();
        anim.SetInteger("state", (int)state); // sets animation based on enumerator state.
        state = State.idle;
        
    }

    // Controls the movement of the player
    private void Movement()
    {
        float hdirection = Input.GetAxis("Horizontal");

        // moving left.
        if (hdirection < 0)
        {
            rb.velocity = new Vector2(-speed, rb.velocity.y);
            transform.localScale = new Vector3(-1, 1, 1);
        }

        // moving right.
        else if (hdirection > 0)
        {
            rb.velocity = new Vector2(speed, rb.velocity.y);
            transform.localScale = new Vector3(1, 1, 1);
        }

        // jumping
        if (Input.GetButtonDown("Jump") && (coll.IsTouchingLayers(ground) || coll.IsTouchingLayers(item)))
        {
            Jump();
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Door")
        {
            anim.SetTrigger("open");
            /*
            if (Input.GetKeyDown(KeyCode.E))
            {
                //door.OpenDoor();
                anim.SetBool("toggled", true);
            }
            if (Input.GetKeyDown(KeyCode.F))
            {
                //door.CloseDoor();
                anim.SetBool("toggled", false);
            }
            */
        }
    }

    // Controls the jump mechanic
    private void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        state = State.jumping;
    }

    private void AnimationState()
    {
        if (state == State.jumping)
        {
            if (rb.velocity.y < 0.1f)
            {
                state = State.falling;
            }
        }

        else if (state == State.falling)
        {
            if (coll.IsTouchingLayers(ground))
            {
                state = State.idle;
            }
        }

        else if (Mathf.Abs(rb.velocity.x) > 2f)
        {
            // Moving
            state = State.running;
        }
        /*
        else if (state == State.crouch)
        {
            collide2D.size = new Vector2(collide2D.size.x, 0.25f); 
        }
        */
        else
        {
            state = State.idle;
        }
    }
}
