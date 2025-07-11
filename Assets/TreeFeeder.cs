using System.Collections;
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
    void Start()
    {
        essenceFed = PlayerPrefs.GetInt("EssenceFedToTree", 0);
        FeedButton.SetActive(false);
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
            Debug.Log("Not enough essence of life.");
            NoFood.gameObject.SetActive(true);
            HideNoFood(2f);
        }
    }
    private IEnumerator HideNoFood(float delay)
    {
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
}
