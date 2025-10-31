using NUnit.Framework.Constraints;
using UnityEngine;

public class EnemyBeahavior : MonoBehaviour
{
    public float speed = 3f;
    private bool _isMovingLeft = true;
    private bool _isAlive = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        IsAlive();
        Movement();
    }

    private void Movement()
    {
        transform.position += _isMovingLeft switch
        {
            true => new Vector3(-speed * Time.deltaTime, 0, 0),
            false => new Vector3(speed * Time.deltaTime, 0, 0)
        };
    }

    private void IsAlive()
    {
        if (!_isAlive)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
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
        }
    }
}