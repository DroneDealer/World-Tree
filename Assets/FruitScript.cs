using UnityEngine;

public class FruitScript : MonoBehaviour
{
    //public int scoreValue = 1;
    public int essenceAmount = 5;
    public bool IsBadFruit = false;
    public EssenceCurrencyManager essenceManager;
    public LogicScript Logic;
    public AudioSource audioSource;
    public AudioClip grabFruit;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (essenceManager == null)
        //Note: '=' is an assignment and '==' is a comparison. please do not forget which is which lest you break your code.
        {
            essenceManager = GameObject.FindObjectOfType<EssenceCurrencyManager>();
        }
        Logic = GameObject.FindGameObjectWithTag("Logic").GetComponent<LogicScript>();
        audioSource = GameObject.FindObjectOfType<AudioSource>();
    }

    // Update is called once per frame
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
