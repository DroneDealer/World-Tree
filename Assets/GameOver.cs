using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverCanvas;
    public TextMeshProUGUI finalScoreText;

    public TextMeshProUGUI highScoreText;
    public LogicScript logicScript;
    public BasicMovements basicMovements;
    public GameObject shopWindowCanvas;
    public FadeIn screenFade;

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
    public void GoToShop()
    {
        StartCoroutine(CutToShop());
    }
    public IEnumerator CutToShop()
    {
        yield return screenFade.fadeIn(0.5f);
        gameOverCanvas.SetActive(false);
        shopWindowCanvas.SetActive(true);
        yield return screenFade.FadeOut(0.5f);
    }
}