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
    public Rigidbody2D ballRb;
    public GameObject particlesPerfab;
    // Start is called before the first frame update
    void Start()
    {
        if (autoMove)
        {
            if (ballRb == null) throw new Exception("Ball has to be set when autoMove is enabled");
        }

    }

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
        //get ball position
        //check if coming in its direction
        // check position on impact
        var distance = Mathf.Abs(ballRb.position.x - rb.position.x);
        if(distance < 6 && Vector2.Dot(ballRb.velocity, rb.position) > 0)
        {
            float predictedY = ballRb.position.y + ballRb.velocity.y * (rb.position.x - ballRb.position.x) / ballRb.velocity.x;
            Debug.Log(predictedY);
            if(!rb.OverlapPoint(new Vector2(rb.position.x, predictedY)))
                return Mathf.Sign(predictedY - rb.position.y);
        }
        //Debug.Log( );
        return 0f;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        ContactPoint2D[] contactPoints = new ContactPoint2D[2];

        collision.GetContacts(contactPoints);
        if (collision.otherCollider.tag == "Player")
        {
            if (Mathf.Abs(contactPoints[0].point.y - collision.otherRigidbody.position.y) < 0.3)
            {
                var obj = Instantiate(particlesPerfab, contactPoints[0].point, Quaternion.identity);
                
                collision.rigidbody.velocity *= 1.2f;
            }
        }
    }
}
