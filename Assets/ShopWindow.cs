using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
public class ShopWindow : MonoBehaviour
{
    public GameObject shopWindowCanvas;
    public GameObject GameOverCanvas;
    public GameObject player;
    public Transform entryPoint;

    public void showShop()
    {
        shopWindowCanvas.SetActive(true);
    }

    public void hideShop()
    {
        shopWindowCanvas.SetActive(false);
    }
    public void WalkToShop()
    {
        Debug.Log("Walk to shop called");
        player.SetActive(true);
        GameOverCanvas.SetActive(false);
        BasicMovements playerMovement = player.GetComponent<BasicMovements>();
        if (playerMovement != null && entryPoint != null)
        {
            playerMovement.shopEntranceTarget = entryPoint;
            playerMovement.AutoWalking = true;
        }
        else
        {
            Debug.LogWarning("Missing player or entry point reference!");
        }
    }
}