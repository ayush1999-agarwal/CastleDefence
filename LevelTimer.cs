using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelTimer : MonoBehaviour
{
    [SerializeField] float baseTime = 10f;
    float levelTime;
    [SerializeField] int timeIncFactror = 5;

    private void Start()
    {
        levelTime = baseTime + PlayerPrefsController.GetMasterDifficulty()*timeIncFactror;
    }

    void Update()
    {
        GetComponent<Slider>().value = Time.timeSinceLevelLoad / levelTime;
        bool levelTimer = (Time.timeSinceLevelLoad >= levelTime);
        if(levelTimer)
        {
            FindObjectOfType<LevelController>().LevelTimerFinished();
        }
    }

}
