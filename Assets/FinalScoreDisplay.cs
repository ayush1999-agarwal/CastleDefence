using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinalScoreDisplay : MonoBehaviour
{
    Text scoreText;
    RestartSceneIndex scorePrefab;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = GetComponent<Text>();
        scorePrefab = FindObjectOfType<RestartSceneIndex>();
        ScoreDisplay();
    }

    private void ScoreDisplay()
    {
        scoreText.text = scorePrefab.GiveCoins().ToString();
    }
}
