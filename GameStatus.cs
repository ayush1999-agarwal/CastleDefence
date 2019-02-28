using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameStatus : MonoBehaviour
{
    [SerializeField] int scoreToDisplay = 5;
    [SerializeField] int damage = 1;
    Text scoreText;
    int currentSceneIndex;

    void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        scoreText = GetComponent<Text>();
        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        scoreText.text = scoreToDisplay.ToString();
    }

    public void DamageBase()
    {
        scoreToDisplay -= damage;
        UpdateDisplay();
        if (scoreToDisplay <= 0)
        {
            LoadLoseScene();
        }
    }

    private void LoadLoseScene()
    {
        FindObjectOfType<LevelLoader>().LoadLoseScene();
        FindObjectOfType<RestartSceneIndex>().GetIndex(currentSceneIndex);
    }

}
