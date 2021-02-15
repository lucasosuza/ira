using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movment attributes")]

    [Range(0.1f,  0.5f)] [SerializeField] private float horizontalAcceleration = 0.25f;

    private Rigidbody2D rigidbody2D;
    private SpriteRenderer spriteRenderer;

    private float old_pos;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        Debug.Log(rigidbody2D);

       
        old_pos = rigidbody2D.transform.position.x;
        Debug.Log("Initial position");

        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    void FixedUpdate()
    {
        MoveHorizontaly();
    }

    private void MoveHorizontaly()
    {
        float moveHorizontalForce = Input.GetAxis("Horizontal") * horizontalAcceleration;

        FlipSprite(moveHorizontalForce);

        Debug.Log(rigidbody2D.velocity.x);




        rigidbody2D.AddForce(new Vector2(moveHorizontalForce, 0), ForceMode2D.Impulse);



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
