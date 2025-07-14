using Unity.VisualScripting;
using UnityEngine;

public class MusicManagerScript : MonoBehaviour
{
    private static MusicManagerScript Instance;
    public AudioSource audioSource;
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Debug.Log("Duplicates exist. get rid of them");
            Destroy(gameObject);
            return;
        }
        audioSource = GameObject.FindObjectOfType<AudioSource>();
        if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.Play();
        }
        else
        {
            Debug.Log("something is missing...");
        }
    }
}
