using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public float Speed = 1f;
    public Rigidbody2D rigidbody2D;
    void Start()
    {
       rigidbody2D = GetComponent<Rigidbody2D>();
        Vector2 newVelocity = new Vector2();
        newVelocity.x = Random.Range(-1f, 1f);
        newVelocity.y = Random.Range(-1f, 1f);
        rigidbody2D.velocity = newVelocity.normalized * Speed;


    }


    void Update()
    {
        
    }
}
