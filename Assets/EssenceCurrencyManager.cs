using System;
using Unity.VisualScripting;
using UnityEngine;
using TMPro;

public class EssenceCurrencyManager : MonoBehaviour
{
    public int essenceAmount;
    public TextMeshProUGUI essenceText;
    public event Action<int> OnEssenceAmountChanged;
    public static EssenceCurrencyManager currencyProgram { get; private set; }
    private void UpdateEssence()
    {
        if (essenceText == null || essenceText.Equals(null))
        {
            GameObject foundText = GameObject.Find("Essencekeeper");
            if (foundText != null)
            {
                essenceText = foundText.GetComponent<TextMeshProUGUI>();
            }
            else
            {
                Debug.LogWarning("EssenceText GameObject not found in this scene.");
                return;
            }
        }
        Debug.Log("Updating Essence Text component: " + essenceText.name + " → " + essenceText.text);
        essenceText.text = "Total Essence of Life: " + essenceAmount;
    }
    void Start()
    {
        UpdateEssence();
    }
    private void Awake()
    {
        if (currencyProgram != null && currencyProgram != this)
        {
            Destroy(gameObject);
            return;
        }
        currencyProgram = this;
        DontDestroyOnLoad(gameObject);
        essenceAmount = PlayerPrefs.GetInt("Tree food", 0);
    }
    public void AddToEssenceAmount(int amount)
    {
        essenceAmount += amount;
        UpdateEssence();
        PlayerPrefs.SetInt("Tree food", essenceAmount);
        PlayerPrefs.Save();
        Debug.Log("Essence added: " + amount + ". Total: " + essenceAmount);
    }
    public bool SpendEssence(int amount)
    {
        if (essenceAmount >= amount)
        {
            essenceAmount -= amount;
            UpdateEssence();
            PlayerPrefs.SetInt("Tree food", essenceAmount);
            PlayerPrefs.Save();
            Debug.Log("Essence of Life spent: " + amount + ". Remaining: " + essenceAmount);
            return true;
        }
        else
        {
            Debug.LogWarning("Not enough Essence to spend!");
            return false;
        }
    }
    public int GetEssenceAmount()
    {
        return essenceAmount;
    }
    [ContextMenu("Reset Essence Amount")]
    public void ResetEssence()
    {
        PlayerPrefs.DeleteKey("Tree food");
        PlayerPrefs.Save();
        essenceAmount = 0;
        UpdateEssence();
    }
}