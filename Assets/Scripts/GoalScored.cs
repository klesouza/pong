using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GoalScored : MonoBehaviour
{
    private int currentScore = 0;
    public Text scoreText;
    public GameController gameController;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        scoreText.text = $"{(++currentScore)}";
        gameController.SpawnBall();
    }
}
