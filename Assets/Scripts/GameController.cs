using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class GameController : MonoBehaviour
{

    public Rigidbody2D rb;
    public float speed = 7f;
    private float yPos;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        yPos = Input.GetAxisRaw("Vertical");
        rb.velocity = new Vector2(rb.velocity.x, yPos * speed);
    }

    private void FixedUpdate()
    {
    }
}
