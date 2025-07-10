using UnityEngine;
using System.Collections;
using TMPro;

public class WorldTreeScript : MonoBehaviour
{
    public GameObject WorldTreeCanvas;
    public GameObject gameOverCanvas;
    public GameObject worldTree;
    public GameObject player;

    void Start()
    {
        WorldTreeCanvas.SetActive(false);
    }

    public void ReturnToGarden()
    {
        WorldTreeCanvas.SetActive(false);
        gameOverCanvas.SetActive(true);
        player.SetActive(false);
    }
}
