using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GameController : MonoBehaviour
{

    public GameObject player1;
    public GameObject player2;
    public GameObject boundaries;
    public GameObject ball;
    Vector3 lastPos;
    // Start is called before the first frame update
    void Start()
    {
        lastPos = player1.transform.position;
        //Debug.Log($"Boundaries: {boundaries.transform.localScale}");
    }

    // Update is called once per frame
    void Update()
    {
        float xPos = Input.GetAxis("Horizontal");
        float yPos = Input.GetAxis("Vertical");
        ball.transform.Translate(Vector3.left * 3 * Time.deltaTime);
        //if(player1.transform.position.y > boundaries.transform.localScale.y  )
            player1.transform.Translate(new Vector3(xPos, yPos));
        if (lastPos != player1.transform.position) 
            Debug.Log($"New position {player1.transform.position}");
        lastPos = player1.transform.position;
    }
}
