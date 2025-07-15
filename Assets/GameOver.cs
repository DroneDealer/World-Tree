using UnityEngine;
using TMPro;

public class GameOver : MonoBehaviour
{
    public GameObject gameOverCanvas;
    public TextMeshProUGUI finalScoreText;
    public TextMeshProUGUI highScoreText;
    public LogicScript logicScript;
    public GameObject shopWindowCanvas;
    public GameObject worldTreeCanvas;
    public Transform treeLocation;
    public GameObject player;
    public GameObject player1;
    public AudioSource audioSource;
    public AudioClip gameOVerMusic;
    void Start()
    {
        audioSource = GameObject.FindObjectOfType<AudioSource>();
        gameOverCanvas.SetActive(false);
    }

    public void GameOverNow()
    {
        //if (audioSource != null && gameOVerMusic != null)
        //{
            //audioSource.Play();
        //}
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
    public void GoToWorldTree()
    {
        gameOverCanvas.SetActive(false);
        worldTreeCanvas.SetActive(true);
        Time.timeScale = 1f;
        player.SetActive(false);
        player1.SetActive(true);
        player.transform.position = treeLocation.position;
    }
    public void GoToShop()
    {
        gameOverCanvas.SetActive(false);
        shopWindowCanvas.SetActive(true);
    }
}