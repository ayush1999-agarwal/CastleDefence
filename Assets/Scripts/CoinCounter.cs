using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinCounter : MonoBehaviour
{
    int coins;
    Text coinText;
    RestartSceneIndex restartSceneIndex;

    private void Start()
    {
        coins = FindObjectOfType<RestartSceneIndex>().GiveCoins();
        restartSceneIndex = FindObjectOfType<RestartSceneIndex>();
        coinText = GetComponent<Text>();
        UpdateDisplay();
    }

    public void UpdateDisplay()
    {
        coinText.text = coins.ToString();
    }

    public bool HaveEnoughStars(int amount)
    {
        return coins >= amount;
    }

    public void AddCoins(int amount)
    {
        coins += amount;
        UpdateDisplay();
    }

    public void SpendCoins(int amount)
    {
        if (coins >= amount)
        {
            coins -= amount;
            UpdateDisplay();
        }
    }

    public void HaveWon()
    {
        FindObjectOfType<RestartSceneIndex>().GetCoins(coins);
    }

}
