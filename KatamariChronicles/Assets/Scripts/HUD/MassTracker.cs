using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MassTracker : MonoBehaviour {

    public GameObject player;

    //Menues for when the player wins

   
    public GameObject minimumWinScreen;

    public GameObject maxSizeWinScreen;
    public float winMinimumTotal;           //Size the player has to gain before they achive minimal victory
    public float sizeMaxAmount;
    float winMinimumTotalHolder;
    public GameObject Timer;        //Need to acess timer to stop timer after achiving minimal victory


    void Start()
    {
        winMinimumTotalHolder = winMinimumTotal;                        //WinMinimumTotal is used in the if statement to display minimum win screen, therefore to continue after winning the minimum amount needs to be changed
    }                                                                   //However the oringal value needs to be kept for the display so its stored

    void Update()
    {
        var sizeTracker = player.GetComponent<PlayerController>().size;
        this.GetComponent<Text>().text = "Mass: " + Math.Round(sizeTracker, 2) + "/" + winMinimumTotalHolder + "m";
        minimalWinRequirments();
        MaxWinRequirments();
    }

    void minimalWinRequirments()    //Once the player reaches the minimal size requirment to win a screen will display that will offer them to continue playing with no limit active
    {
        if (player.GetComponent<PlayerController>().size >= winMinimumTotal)
        {
            minimumWinScreen.gameObject.SetActive(true);
            Timer.GetComponent<Timer>().gameStart = false;
            Time.timeScale = 0;
            winMinimumTotal = sizeMaxAmount+1;
        }
    }
    void MaxWinRequirments()    //Once the player collects all objects the game ends 
    {
        if (player.GetComponent<PlayerController>().size >= sizeMaxAmount)
        {
            maxSizeWinScreen.gameObject.SetActive(true);
            Time.timeScale = 0;
           
        }
    }
}
