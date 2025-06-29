using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverCanvas;
    public TextMeshProUGUI finalScoreText;
    public LogicScript logicScript;

    public void GameOverNow()
    {
        gameOverCanvas.SetActive(true);
        Time.timeScale = 0f;
        finalScoreText.text = "Score: " + logicScript.playerScore.ToString();
    }

    public void RestartGame()
    {
        Debug.Log("Restart Button clicked");
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
