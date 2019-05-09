using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;


public class Timer : MonoBehaviour {

    public float gameTimer=300;

    bool gameStart;

    bool gameEnd;

    int seconds;
    int minutes;
    int hour;

    void Start()
    {
        gameStart = true;
    }
    void Update()
    {
        
        
        while (gameStart == true)
        {
            gameTimer -= Time.deltaTime;
            seconds = (int)(gameTimer % 60);
            minutes = (int)(gameTimer / 60) % 60;
            hour = (int)(gameTimer / 3600) / 24;

            if (gameTimer <= 0)
            {
                gameStart = false;
                gameEnd = true;
            }
        }
        string timerString = string.Format("{0:0}:{1:00}:{2:00}", hour, minutes, seconds);
        print(gameTimer);
        this.GetComponent<Text>().text =timerString;
    }
}
