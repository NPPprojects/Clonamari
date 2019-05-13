using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;


public class Timer : MonoBehaviour {

    public float gameTimer;
    public GameObject loseScreen;
    public bool gameStart;

    bool gameEnd;
    //vales for timer
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
            //Displays Timer in minutes and seconds
            minutes = ((int)gameTimer/ 60).ToString("00");
            seconds = (gameTimer % 60).ToString("00");
            


            if (gameTimer <= 0)
            {
                gameStart = false;
                gameEnd = true;
                print("This");
            }
        }
       
  
        this.GetComponent<Text>().text = minutes + ":" + seconds;
        EndGame();
    }


    void EndGame()          //FailState
    {
        if (gameEnd == true)
        {
            print("Works");
            loseScreen.gameObject.SetActive(true);
            Time.timeScale = 0;
        }
        
    }
    
}


