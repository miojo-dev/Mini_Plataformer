using UnityEngine;
using UnityEngine.Serialization;

public class PlayerControl : MonoBehaviour
{
    public float speed = 10f;
    public float jumpForce = 36f;
    public int manyJumps = 1;
    public int jumpsLeft;
    private int _lifes = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        jumpsLeft = manyJumps;
    }

    // Update is called once per frame
    private void Update()
    {
        Movement();
        IsAlive();
    }

    public bool IsAlive()
    {
        if (_lifes <= 0)
        {
            Kill();
            return false;
        }

        return true;
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Obstacle" or "Ground":
                jumpsLeft = manyJumps;
                break;
            case "Enemy":
                _lifes--;
                break;
        }
    }

    public int GetLifes()
    {
        if (_lifes < 0)
        {
            return 0;
        }
        return _lifes;
    }

    public void Kill()
    {
        _lifes = 0;
        Destroy(this.gameObject);
    }
}