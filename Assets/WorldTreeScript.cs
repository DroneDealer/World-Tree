using UnityEngine;
using System.Collections;
using TMPro;

public class WorldTreeScript : MonoBehaviour
{
    public GameObject WorldTreeCanvas;
    public GameObject gameOverCanvas;
    public GameObject worldTree;
    public GameObject player1;
    public AudioSource audioSoruce;
    public AudioClip WorldTreeMusic;
    void Start()
    {
        player1.SetActive(true);
        audioSoruce = GameObject.FindObjectOfType<AudioSource>();
        WorldTreeCanvas.SetActive(false);
    }

    public void ReturnToGarden()
    {
        WorldTreeCanvas.SetActive(false);
        gameOverCanvas.SetActive(true);
        player1.SetActive(false);
    }
}
