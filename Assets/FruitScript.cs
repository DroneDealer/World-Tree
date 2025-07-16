using UnityEngine;

public class FruitScript : MonoBehaviour
{
    public int essenceAmount = 5;
    public bool IsBadFruit = false;
    public EssenceCurrencyManager essenceManager;
    public LogicScript Logic;
    public AudioSource audioSource;
    public AudioClip grabFruit;
    void Start()
    {
        if (essenceManager == null)
        //Note: '=' is an assignment and '==' is a comparison. please do not forget which is which lest you break your code.
        {
            essenceManager = GameObject.FindObjectOfType<EssenceCurrencyManager>();
            // Learned "find object of type" command from a Unity Flappy Bird tutorial; very useful since I don't have to manually assign everything
        }
        Logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        audioSource = GameObject.FindObjectOfType<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (audioSource != null && grabFruit != null)
        {
            audioSource.PlayOneShot(grabFruit);
        }
        else
        {
            Debug.Log("Either your audio manager or your audio clip are unassigned!");
        }
        if (IsBadFruit)
        {
            Logic.LoseLife();
        }
        else
        {
            Logic.addScore(essenceAmount);
            essenceManager.AddToEssenceAmount(essenceAmount);
            Destroy(gameObject);
        }
    }
}
