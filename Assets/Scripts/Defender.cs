using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defender : MonoBehaviour
{
    [SerializeField] int coinValue = 100;

    public void AddCoins(int amount)
    {
        FindObjectOfType<CoinCounter>().AddCoins(amount);
    }

    public int GetCoinValue()
    {
        return coinValue;
    }
}
