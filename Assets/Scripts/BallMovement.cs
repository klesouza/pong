using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{

    public Rigidbody2D rigidbody2D;
    public float speed = 4f;
    public float speedIncrease = 0.1f;
    // Start is called before the first frame update
    void Start()
    {

        Vector2 velocity = new Vector2(Random.Range(1f, 2f), Random.Range(1f, 2f));
        rigidbody2D.velocity = velocity * speed;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if(Time.fixedDeltaTime % 6 == 0)
            rigidbody2D.velocity *= (1+speedIncrease);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log($"Ball bounced {collision.collider.name}");

    }
}
