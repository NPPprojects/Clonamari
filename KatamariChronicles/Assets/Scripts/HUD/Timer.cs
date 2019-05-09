using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;


public class Timer : MonoBehaviour {

    public float gameTimer=300;

    bool gameStart;

    bool gameEnd;

    string seconds;
    string minutes;
   

    void Start()
    {
        gameStart = true;
        gameEnd = false;
    }
    void Update()
    {
        
        
        if (gameStart == true)
        {
            gameTimer -= Time.deltaTime;
            minutes = ((int)gameTimer/ 60).ToString("00");
            seconds = (gameTimer % 60).ToString("00");
            


            if (gameTimer <= 0)
            {
                gameStart = false;
                gameEnd = true;
            }
        }
       
   
        this.GetComponent<Text>().text = minutes + ":" + seconds;
    }
}
