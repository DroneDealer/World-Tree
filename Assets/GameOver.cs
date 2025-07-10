using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverCanvas;
    public TextMeshProUGUI finalScoreText;
    public TextMeshProUGUI highScoreText;
    public LogicScript logicScript;
    public GameObject shopWindowCanvas;
    void Start()
    {
        gameOverCanvas.SetActive(false);
    }

    public void GameOverNow()
    {
        logicScript.CheckHighScore();
        gameOverCanvas.SetActive(true);
        Time.timeScale = 0f;
        finalScoreText.text = "Score: " + logicScript.playerScore.ToString();
        highScoreText.text = "High Score: " + logicScript.GetHighScore().ToString();
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }

    public void GoToShop()
    {
        gameOverCanvas.SetActive(false);
        shopWindowCanvas.SetActive(true);
    }
}