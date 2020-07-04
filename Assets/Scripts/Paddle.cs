using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class Paddle : MonoBehaviour
{

    public Rigidbody2D rb;
    public float speed = 7f;
    private float yPos;
    public bool autoMove = false;
    Rigidbody2D ballRb = null;
    public GameObject particlesPerfab;

    public float paddleCenterRadius = 0.5f;

    // Update is called once per frame
    void Update()
    {
        yPos = getMovement();
    }

    private float getMovement()
    {
        return autoMove ? AutoMove() : Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(rb.velocity.x, yPos * speed);
    }

    private float AutoMove()
    {
        // get ball position
        // check if coming in its direction
        // check position on impact
        if (ballRb != null)
        {
            if (Mathf.Abs(ballRb.position.x) > Mathf.Abs(rb.position.x)) //Ball out of field
                ballRb = null;
            else
            {
                var distance = Mathf.Abs(ballRb.position.x - rb.position.x);
                if (distance < 6 && Vector2.Dot(ballRb.velocity, rb.position) > 0)
                {
                    float predictedY = ballRb.position.y + ballRb.velocity.y * (rb.position.x - ballRb.position.x) / ballRb.velocity.x;
                    if (!rb.OverlapPoint(new Vector2(rb.position.x, predictedY)))
                        return Mathf.Sign(predictedY - rb.position.y);
                }
            }
        }
        return 0f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ContactPoint2D[] contactPoints = new ContactPoint2D[2];

        collision.GetContacts(contactPoints);
        if (collision.otherCollider.tag == "Player")
        {
            if (Mathf.Abs(contactPoints[0].point.y - collision.otherRigidbody.position.y) < paddleCenterRadius)
            {
                var obj = Instantiate(particlesPerfab, contactPoints[0].point, Quaternion.identity);

                collision.rigidbody.velocity *= 1.2f;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ContactPoint2D[] contactPoints = new ContactPoint2D[2];

        collision.GetContacts(contactPoints);
        if (collision.tag == "Ball")
        {
            if (ballRb == null)
                ballRb = collision.GetComponent<Rigidbody2D>();
            else
                ballRb = null;
        }

    }
}
