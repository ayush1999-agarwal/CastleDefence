using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartSceneIndex : MonoBehaviour
{
    [SerializeField] int coins = 1000;
    int index;

    private void Awake()
    {
        int count = FindObjectsOfType<RestartSceneIndex>().Length;
        if (count > 1)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    public void GetIndex(int restartIndex)
    {
        index = restartIndex;
    }

    public int GiveIndex()
    {
        return index;
    }

    public void GetCoins(int amount)
    {
        coins = amount;
    }

    public int GiveCoins()
    {
        return coins;
    }

}
