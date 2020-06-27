using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{

    public Rigidbody2D rigidbody2D;
    public float speed = 4f;
    // Start is called before the first frame update
    void Start()
    {

        Vector2 velocity = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        rigidbody2D.velocity = velocity * speed;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log($"Ball bounced {collision.collider.name}");

    }
}
