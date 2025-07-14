using System.Collections;
using System.Runtime.CompilerServices;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
public class TreeFeeder : MonoBehaviour
{
    public Animator treeAnimator;
    public int essenceCost = 2500;
    private int essenceFed = 0;
    public GameObject FeedButton;
    public TextMeshProUGUI NeedForFeed;
    public TextMeshProUGUI NoFood;
    //Like "need for speed". from Sonic. Haha
    public AudioSource audioSource;
    public AudioClip treeGrowth;
    public AudioClip noFood;
    public DialogueScript treeDialogueManager;
    void Start()
    {
        audioSource = GameObject.FindObjectOfType<AudioSource>();
        essenceFed = PlayerPrefs.GetInt("EssenceFedToTree", 0);
        FeedButton.SetActive(false);
        NoFood.gameObject.SetActive(false);
        UpdateEssenceFed();
    }
    void UpdateEssenceFed()
    {
        NeedForFeed.text = $"Essence Fed: {essenceFed} / {essenceCost}";
    }
    public void FeedTree()
    {
        int CurrentEssence = EssenceCurrencyManager.currencyProgram.GetEssenceAmount();
        if (CurrentEssence > 0)
        {
            EssenceCurrencyManager.currencyProgram.SpendEssence(CurrentEssence);
            essenceFed += CurrentEssence;
            PlayerPrefs.SetInt("EssenceFedToTree", essenceFed);
            PlayerPrefs.Save();
            UpdateEssenceFed();
            Debug.Log("Fed tree. Progress: " + essenceFed + " / " + essenceCost);
            if (essenceFed >= essenceCost)
            {
                treeAnimator.SetTrigger("Grow");
                Debug.Log("Tree has grown!");
            }
        }
        else
        {
            if (audioSource != null && noFood != null)
            {
                audioSource.PlayOneShot(noFood);
            }
            else
            {
                Debug.Log("Either your Audio Source or your Audio Clip is missing!");
            }
            Debug.Log("Not enough essence of life.");
            NoFood.gameObject.SetActive(true);
            HideNoFood(2f);
        }
    }
    private IEnumerator HideNoFood(float delay)
    {
        NoFood.gameObject.SetActive(true);
        yield return new WaitForSeconds(delay);
        NoFood.gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D thing)
    {
        if (thing.CompareTag("Player"))
        {
            FeedButton.SetActive(true);
            UpdateEssenceFed();
        }
    }
    private void OnTriggerExit2D(Collider2D thing)
    {
        if (thing.CompareTag("Player"))
        {
            FeedButton.SetActive(false);
        }
    }
    [ContextMenu("Reset essence fed")]
    public void ResetEssenceFed()
    {
        PlayerPrefs.DeleteKey("EssenceFedToTree");
        PlayerPrefs.Save();
        essenceFed = 0;
        UpdateEssenceFed();
        Debug.Log("Tree essence fed reset");
    }
    private IEnumerator BeginDialogue()
    {
        yield return new WaitForSeconds(1f);
        //DialogueScript.dialogueBubble.SetActive(true);
    }
}