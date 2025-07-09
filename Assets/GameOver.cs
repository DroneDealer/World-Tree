using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverCanvas;
    public TextMeshProUGUI finalScoreText;

    public TextMeshProUGUI highScoreText;
    public LogicScript logicScript;
    public BasicMovements basicMovements;
    public GameObject shopWindowCanvas;

    void Start()
    {
        gameOverCanvas.SetActive(false);
        shopWindowCanvas.SetActive(false);
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
        Debug.Log("Restart Button clicked");
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void startShowShop()
    {
        Debug.Log("go to shop clicked");
        gameOverCanvas.SetActive(false);
        shopWindowCanvas.SetActive(true);
        Time.timeScale = 0f;
    }
}