using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [Header("Player Movement")]
    [Range(0.0f, 100.0f)]
    public float HorizontalForce;
    public Bounds Bounds;
    [Range(0.0f, 0.99f)]
    public float Decay;

    private Rigidbody2D rigidbody;


    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        CheckBounds();
    }

    private void Move()
    {
        var x = Input.GetAxisRaw("Horizontal");

        rigidbody.AddForce(new Vector2(x * HorizontalForce, 0.0f));

        rigidbody.velocity *= (1.0f - Decay);
    }

    private void CheckBounds()
    {
        // left bounds
        if (transform.position.x < Bounds.min)
        {
            transform.position = new Vector2(Bounds.min, transform.position.y);
        }

        // right bounds
        if (transform.position.x > Bounds.max)
        {
            transform.position = new Vector2(Bounds.max, transform.position.y);
        }
    }
}
