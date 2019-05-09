using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class MassTracker : MonoBehaviour {

    public GameObject player;

    void Update()
    {
        var sizeTracker = player.GetComponent<PlayerController>().size;
        this.GetComponent<Text>().text = "Mass: " + Math.Round(sizeTracker,2) + "/10m";
        
    }
}
