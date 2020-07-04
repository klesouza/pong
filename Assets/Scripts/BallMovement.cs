using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{

    public Rigidbody2D rb;
    public float speed = 4f;
    public float speedIncrease = 0.1f;
    // Start is called before the first frame update
    void Start()
    {

        Vector2 velocity = new Vector2(Random.Range(1f, 2f), Random.Range(1f, 2f));
        rb.velocity = velocity * speed;
    }

    private void FixedUpdate()
    {
        if(Time.fixedDeltaTime % 6 == 0)
            rb.velocity *= (1+speedIncrease);
    }
}
