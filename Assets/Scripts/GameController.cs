using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class GameController : MonoBehaviour
{

    public Rigidbody2D rb;
    public float speed = 7f;
    private float yPos;
    public bool autoMove = false;
    public Rigidbody2D ballRb;
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
}
