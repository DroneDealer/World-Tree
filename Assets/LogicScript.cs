using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public Text scoreText;

    public int currentLives;    //public GameObject GameOverScreen;
    public Text livesText;

    [ContextMenu("Increase Score")]
    public void addScore()
    {
        playerScore = playerScore + 1;
        scoreText.text = playerScore.ToString();
    }

    [ContextMenu("Lose A Life")]
    public void LoseLife()
    {
        currentLives -= 1;
        livesText.text = "Lives: " + currentLives.ToString();

        if (currentLives <= 0)
        {
            Debug.Log("Game Over!");
            Time.timeScale = 0f;
        }
    }

    // public void restartGame()
    // {
    //     SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    // }

    // public void gameOver()
    // {
    //     GameOverScreen.SetActive(true);
    // }
}