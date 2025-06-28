using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class LogicScript : MonoBehaviour
{
    public int playerScore;
    public TextMeshProUGUI scoreText;

    public int currentLives;    //public GameObject GameOverScreen;
    public TextMeshProUGUI livesText;

    void Start()
    {
        scoreText.text = "Score: " + playerScore.ToString();
        livesText.text = "Lives: " + currentLives.ToString();
    }

    [ContextMenu("Increase Score")]
    public void addScore(int value)
    {
        playerScore += value;
        scoreText.text = "Score: " + playerScore.ToString();
    }

    [ContextMenu("Lose A Life")]
    public void LoseLife()
    {
        currentLives = currentLives - 1;
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