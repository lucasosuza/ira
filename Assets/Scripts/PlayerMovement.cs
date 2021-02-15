using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movment attributes")]

    //[Range(0.2f, 0.5f)]
    public float horizontalAcceleration = 0.4f;

    private Rigidbody2D rigidbody2D;
    private bool isMoving;
    private float old_pos;


    private SpriteRenderer spriteRenderer;
    private Animator animator;

    public bool IsMoving {
        get { return isMoving; }
    }

    

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        Debug.Log(rigidbody2D);

       
        old_pos = rigidbody2D.transform.position.x;
        Debug.Log("Initial position");

        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    void FixedUpdate()
    {
        MoveHorizontaly();

        if (isMoving)
        {
            animator.SetBool("IsRunning", true);
        }
        else {
            animator.SetBool("IsRunning", false);
        }
    }

    private void MoveHorizontaly()
    {
        float moveHorizontalForce = Input.GetAxis("Horizontal") * horizontalAcceleration;

        FlipSprite(moveHorizontalForce);

        rigidbody2D.AddForce(new Vector2(moveHorizontalForce, 0), ForceMode2D.Impulse);

        // update running animation
        if (rigidbody2D.velocity.magnitude < 0.01)
        {
            isMoving = false;
        }
        else {
            isMoving = true;
        }

        
    }

    private void FlipSprite(float moveHorizotal)
    {
        if (moveHorizotal < 0)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }
}
