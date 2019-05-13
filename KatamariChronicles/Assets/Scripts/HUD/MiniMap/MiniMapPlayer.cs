using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapPlayer : MonoBehaviour {

    public GameObject player;
    // Not parenting the sprite to the parent as that would result with it rotating with the player inside the mini map
    void Update ()
    {
        gameObject.transform.position = player.transform.position; 
	}
}
