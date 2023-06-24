using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class BallController : MonoBehaviour
{
    public float Speed = 1f;
    public Rigidbody2D rigidbody2D;
    public Vector2 vel;
    public bool GameStarted;
    public ScoreManager scoreManager;

    void Start()
    {
       rigidbody2D = GetComponent<Rigidbody2D>();
            SendBallToRandomDirection();
    }
    private void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space)&&GameStarted ==false)
        {
            SendBallToRandomDirection();
        }
            
    }
    private void SendBallToRandomDirection()
    {
        rigidbody2D.velocity = Vector2.zero;
        transform.position = Vector2.zero;
        rigidbody2D.velocity = GenerateRandomVector2Without0(true) * Speed;
        vel = rigidbody2D.velocity;
        GameStarted = true;

    }


    private Vector2 GenerateRandomVector2Without0(bool shouldReturnNormalized)
    {
        Vector2 newVelocity = new Vector2();
        bool shouldGoRight = Random.Range(1, 100) > 50;
        newVelocity.x = shouldGoRight ? Random.Range(8f, 2f) : Random.Range(-8f, -2f);
        newVelocity.y = shouldGoRight ? Random.Range(8f, 2f) : Random.Range(-8f, -2f);

        if (shouldReturnNormalized)
        {
            return newVelocity.normalized;
        }
            return newVelocity;
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        rigidbody2D.velocity = Vector2.Reflect(vel, collision.contacts[0].normal);
        vel = rigidbody2D.velocity;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (transform.position.x > 0)
        {
            scoreManager.IncrementLeftPlayerScore();
        }
        if (transform.position.x < 0)
        {
            scoreManager.IncrementRightPlayerScore();
        }
        rigidbody2D.velocity = Vector2.zero;
        transform.position = Vector2.zero;
        GameStarted = false;
        
    }
}
