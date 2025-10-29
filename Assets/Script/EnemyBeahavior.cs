using NUnit.Framework.Constraints;
using UnityEngine;

public class EnemyBeahavior : MonoBehaviour
{
    public float speed = 3f;
    private bool _isMovingLeft = true;
    private bool _isAlive = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        IsAlive();
        Movement();
    }

    private void Movement()
    {
        switch (_isMovingLeft)
        {
            case true:
            {
                transform.position += new Vector3(
                    -speed * Time.deltaTime, 0, 0
                );
            }
                break;
            case false:
            {
                transform.position += new Vector3(
                    speed * Time.deltaTime, 0, 0
                );
            }
                break;
        }
    }

    private void IsAlive()
    {
        if (!_isAlive)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        var collidedObject = collision.gameObject;
        switch (collidedObject.tag)
        {
            case "Obstacle":
                _isMovingLeft = !_isMovingLeft;
                collidedObject.GetComponent<SpriteRenderer>().flipX = !_isMovingLeft;
                break;
            case "PlayerDmg":
                _isAlive = false;
                collidedObject.GetComponent<Rigidbody2D>().linearVelocityY = 25;
                collidedObject.GetComponent<PlayerControl>().jumpsLeft =
                    collidedObject.GetComponent<PlayerControl>().manyJumps;
                break;
            case "Player":
                Destroy(collidedObject);
                break;
        }
    }
}