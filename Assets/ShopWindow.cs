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
        Debug.Log("Showing shop");
        if (shopWindowCanvas != null)
        {
            shopWindowCanvas.SetActive(true);
        }
        else
        {
            Debug.LogWarning("No shopWindowCanvas assigned");
        }
    }

    public void hideShop()
    {
        shopWindowCanvas.SetActive(false);
    }
    public void WalkToShop()
    {
        Debug.Log("Start of WalkToShop()");
        if (player == null || entryPoint == null)
        {
            Debug.LogError("Either 'player' or 'entryPoint' is null");
            return;
        }
        if (GameOverCanvas != null)
        {
            GameOverCanvas.SetActive(false);
            Debug.Log("Game Over canvas deactivated");
        }
        BasicMovements playerMovement = player.GetComponent<BasicMovements>();
        Debug.Log("Setting shop target and enabling AutoWalking");
        playerMovement.shopEntranceTarget = entryPoint;
        playerMovement.AutoWalking = true;
    }
}