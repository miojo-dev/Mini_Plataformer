using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float speed = 20.0f;
    public float jumpForce = 50.0f;
    public int manyJumps = 1;
    public int jumpsLeft;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        jumpsLeft = manyJumps;
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
    }

    private void Movement()
    {
        var xInput = Input.GetAxis("Horizontal");
        var playerBody = this.GetComponent<Rigidbody2D>();

        playerBody.linearVelocityX = xInput * speed;

        if (
            (
                Input.GetKey(KeyCode.Space) ||
                Input.GetKey(KeyCode.W) ||
                Input.GetKey(KeyCode.UpArrow)
            ) && jumpsLeft > 0
        )
        {
            playerBody.linearVelocityY = jumpForce;
            jumpsLeft--;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag is "Ground" or "Enemy" or "Obstacle")
        {
            jumpsLeft = manyJumps;
        }
    }
}