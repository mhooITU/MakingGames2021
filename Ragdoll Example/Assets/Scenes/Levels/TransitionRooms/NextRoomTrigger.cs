﻿using System;
using System.Collections;
using System.Collections.Generic;
using PlayerScripts;
using UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NextRoomTrigger : MonoBehaviour
{
    public String sceneToLoad; 
    [Tooltip("The amount of time that is expected for the player to complete this particular level")]
    public int expectedSecondsToCompleteLevel = 90; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerController>())
        {
            PlayerPrefs.SetInt(SceneManager.GetActiveScene().name, 1);
            // PlayerPrefs.SetInt("bossLevel", 0);

            if (FindObjectOfType<ScoreController>())
                FindObjectOfType<ScoreController>().LevelCompleted(expectedSecondsToCompleteLevel);

            FindObjectOfType<GameController>().LoadScene(sceneToLoad, true);
        }
        
    }
}
