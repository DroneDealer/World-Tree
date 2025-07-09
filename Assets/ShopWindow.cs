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
        //Debug.Log("player: " + player + ", entryPoint: " + entryPoint);
        Debug.Log("Start of WalkToShop()");
        if (player == null || entryPoint == null)
        {
            Debug.LogError("Either 'player' or 'entryPoint' is null");
            return;
        }
        BasicMovements playerMovement = player.GetComponent<BasicMovements>();
        Debug.Log($"[ShopWindow] Targeting player instance ID: {playerMovement.GetInstanceID()}");
        Debug.Log("Setting shop target and enabling AutoWalking");
        Debug.Log($"Found BasicMovements on player? { (playerMovement != null)}");
        playerMovement.shopEntranceTarget = entryPoint;
        playerMovement.AutoWalking = true;
    }
    public void StartPlayerWalkToShop()
    {
        Debug.Log("StartPlayerWalkToShip() called");
        if (GameOverCanvas != null)
        {
            GameOverCanvas.SetActive(false);
            Debug.Log("Game Over canvas deactivated");
        }
        WalkToShop();
    }
}