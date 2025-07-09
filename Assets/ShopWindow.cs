using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class ShopWindow : MonoBehaviour
{
    public GameObject shopWindowCanvas;
    public GameObject player;

    void Start()
    {
        shopWindowCanvas.SetActive(false);
    }
    public void showShop()
    {
        Debug.Log("Showing shop");
        if (shopWindowCanvas != null)
        {
            shopWindowCanvas.SetActive(true);
            Time.timeScale = 0f;
            player.SetActive(false);
        }
        else
        {
            Debug.LogWarning("No shopWindowCanvas assigned");
        }
    }

    public void hideShop()
    {
        shopWindowCanvas.SetActive(false);
        Time.timeScale = 1f;
    }
}