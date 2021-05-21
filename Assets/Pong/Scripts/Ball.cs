using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Ball : MonoBehaviour
{
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Invoke(nameof(ServeBall), 2);
    }

    void ServeBall()
    {
        float rand = Random.Range(0, 2);
        if (rand < 1)
        {
            rb.AddForce(new Vector2(40, -35));
        }
        else
        {
            rb.AddForce(new Vector2(-40, -35));
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            Vector2 vel;
            var velocity = rb.velocity;
            vel.x = velocity.x;
            vel.y = (velocity.y / 2) + (other.collider.attachedRigidbody.velocity.y / 3);
            velocity = vel;
            rb.velocity = velocity;
        }
    }
}
