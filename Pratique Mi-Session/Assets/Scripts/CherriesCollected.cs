using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CherriesCollected : MonoBehaviour
{
    private const string CherriesKey = "CHERRIES_COLLECTED";
    TMP_Text cherriesCollectedText;
    int totalCherriesCollected;

    private void Start()
    {
        cherriesCollectedText = GetComponent<TMP_Text>();
        totalCherriesCollected = PlayerPrefs.GetInt(CherriesKey);
        UpdateText();
    }

    internal void CollectFruit()
    {
        totalCherriesCollected++;
        PlayerPrefs.SetInt(CherriesKey, totalCherriesCollected);
        UpdateText();
    }

    private void UpdateText()
    {
        cherriesCollectedText.text = "X " + totalCherriesCollected;
    }

    
}
