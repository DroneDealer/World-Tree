using System;
using UnityEngine;

public class EssenceCurrencyManager : MonoBehaviour
{
    public int essenceAmount = 0;
    public event Action<int> OnEssenceAmountChanged;
    public void AddToEssenceAmount(int amount)
    {
        essenceAmount += amount;
        OnEssenceAmountChanged?.Invoke(essenceAmount);
        Debug.Log("Essence added: " + amount + ". Total: " + essenceAmount);
    }

    public bool SpendEssence(int amount)
    {
        if (essenceAmount >= amount)
        {
            essenceAmount -= amount;
            OnEssenceAmountChanged?.Invoke(essenceAmount);
            Debug.Log("Essence spent: " + amount + ". Remaing: " + essenceAmount);
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
}