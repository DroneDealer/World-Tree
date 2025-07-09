using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;
public class ShopWindow : MonoBehaviour
{
    public GameObject shopWindowCanvas;
    public GameObject gameOverCanvas;
    public GameObject player;
    public FadeIn screenFade;

    void Start()
    {
        shopWindowCanvas.SetActive(false);
    }
    public void GoBackToGameOver()
    {
        StartCoroutine(ExitShop());
    }
    public IEnumerator ExitShop()
    {
        yield return screenFade.fadeIn(0.5f);
        shopWindowCanvas.SetActive(false);
        gameOverCanvas.SetActive(true);
        yield return new WaitForSecondsRealtime(1f);
        yield return screenFade.FadeOut(0.5f);
    }
}