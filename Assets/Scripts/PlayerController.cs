using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    // jump is higher than movement speed because going against gravity
    public float jumpSpeed = 8f;
    private float direction = 0f;
    private Rigidbody2D player;

    // linked to obj in game, check if marker on player touching ground
    public Transform groundCheck;
    public float groundCheckRadius;
    // use layers to specify what is ground
    public LayerMask groundLayer;
    private bool isTouchingGround;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // check if the ground check circle is overlapping with the ground layer
        isTouchingGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);
        
        // gets input from key
        direction = Input.GetAxis("Horizontal");

        // positive, moving right
        if (direction > 0f) {
            // in vector, first is x : second is y
            player.velocity = new Vector2(direction * speed, player.velocity.y);
            transform.localScale = new Vector2(1f, 1f);
        }
        // negative, moving left
        else if(direction < 0f) {
            player.velocity = new Vector2(direction * speed, player.velocity.y);
            transform.localScale = new Vector2(-1f, 1f);
        }
        // if nothing is pressed, no movement
        else {
            player.velocity = new Vector2(0, player.velocity.y);

        }

        if (Input.GetButtonDown("Jump") && isTouchingGround ) {
            // Debug.Log(isTouchingGround);
            player.velocity = new Vector2(player.velocity.x, jumpSpeed);
        }
    }
}
