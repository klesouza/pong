using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameController : MonoBehaviour
{

    public GameObject ballPrefab;
    GameObject currentBall;

    // Start is called before the first frame update
    void Start()
    {
        SpawnBall();
    }

    public void SpawnBall(){
        if(currentBall != null)
            Destroy(currentBall, 1);
        currentBall = Instantiate(ballPrefab, Vector3.zero, Quaternion.identity);
    }
}
