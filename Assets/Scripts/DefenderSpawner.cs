using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    Defender defender;
    GameObject defenderParent;
    bool isSpawning = true;

    const string DEFENDER_PARENT_NAME = "Defenders";

    private void Start()
    {
        CreateDefenderParent();
    }

    private void CreateDefenderParent()
    {
        defenderParent = GameObject.Find(DEFENDER_PARENT_NAME);
        if(!defenderParent)
        {
            defenderParent = new GameObject(DEFENDER_PARENT_NAME);
        }
    }

    private void OnMouseDown()
    {
        if (isSpawning)
        {
            AttemptToPlaceDefender(GetSquareClicked());
        }
    }

    public void DefenderSelection(Defender defenderToSelect)
    {
        defender = defenderToSelect;
    }

    private void AttemptToPlaceDefender(Vector2 gridPos)
    {
        var coinCounter = FindObjectOfType<CoinCounter>();
        int defenderCost = defender.GetCoinValue();
        if(coinCounter.HaveEnoughStars(defenderCost))
        {
            SpawnDefender(gridPos);
            coinCounter.SpendCoins(defenderCost);
        }
    }

    private Vector2 GetSquareClicked()
    {
        Vector2 clickPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 worldPos = Camera.main.ScreenToWorldPoint(clickPos);
        Vector2 gridPos = SnapToGrid(worldPos);
        return gridPos;
    }

    private Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        float newX = Mathf.RoundToInt(rawWorldPos.x);
        float newY = Mathf.RoundToInt(rawWorldPos.y);
        if (rawWorldPos.x > newX)
        {
            newX += 0.5f;
        }
        else
        {
            newX -= 0.5f;
        }

        if (rawWorldPos.y > newY)
        {
            newY += 0.5f;
        }
        else
        {
            newY -= 0.5f;
        }
        return new Vector2(newX, newY);
    }

    private void SpawnDefender(Vector2 worldPos)
    {
        Defender newDefender = Instantiate(
            defender, 
            worldPos, 
            transform.rotation) as Defender;
        newDefender.transform.parent = defenderParent.transform;
    }

    public void HaveWon()
    {
        isSpawning = false;
    }

}
