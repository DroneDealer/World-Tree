using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class LogicScript : MonoBehaviour

{
    [Header("Score")]
    public int playerScore;
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;
    [Header("Lives")]
    public int currentLives;    //public GameObject GameOverScreen;
    public TextMeshProUGUI livesText;    
    [Header("Essence Management")]
    public int essenceAmount;
    public TextMeshProUGUI essenceText;
    void Start()
    {
        scoreText.text = "Score: " + playerScore.ToString();
        livesText.text = "Lives: " + currentLives.ToString();

        int savedHighScore = PlayerPrefs.GetInt("highScore", 0);
        highScoreText.text = "High Score: " + savedHighScore.ToString();
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
            CheckHighScore();
            Debug.Log("Game Over!");
            GameObject.FindWithTag("Player").GetComponent<BasicMovements>().Die();
        }
    }

    public void CheckHighScore()
    {
        int savedHighScore = PlayerPrefs.GetInt("highScore", 0);
        if (playerScore > savedHighScore)
        {
            PlayerPrefs.SetInt("highScore", playerScore);
            PlayerPrefs.Save();
            Debug.Log("New High Score: " + playerScore);
        }
        if (highScoreText != null)
        {
            highScoreText.text = "High Score: " + playerScore.ToString();
        }
    }

    public int GetHighScore()
    {
        return PlayerPrefs.GetInt("highScore", 0);
    }
}