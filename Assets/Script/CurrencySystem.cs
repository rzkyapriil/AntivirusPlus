using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CurrencySystem : MonoBehaviour
{
    public TextMeshProUGUI txtCurrencyCount;
    public int defaultCurrencyCount;
    public int currencyCount;

    public void Init()
    {
        currencyCount = defaultCurrencyCount;
        UpdateUI();
    }

    public void Gain(int val)
    {
        currencyCount += val;
        UpdateUI();
    }

    public bool Use(int val)
    {
        if (EnoughCurrency(val))
        {
            currencyCount -= val;
            UpdateUI();
            return true;
        }
        else
        {
            return false;
        }    
    }

    public bool EnoughCurrency(int val)
    {
        if (val <= currencyCount)
        {
            return true;
        }
        else
            return false;
    }

    void UpdateUI()
    {
        txtCurrencyCount.text = currencyCount.ToString();
    }
}
