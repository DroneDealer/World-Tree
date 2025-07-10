using UnityEngine;
using System.Collections;
using TMPro;

public class ShopWindow : MonoBehaviour
{
    public GameObject shopWindowCanvas;
    public GameObject gameOverCanvas;

    void Start()
    {
        shopWindowCanvas.SetActive(false);
    }

    public void ExitShop()
    {
        shopWindowCanvas.SetActive(false);
        gameOverCanvas.SetActive(true);
    }
}