using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestingCollectablesObjects : MonoBehaviour {

    public GameObject player; //

    public Transform category; // Default category in which the object will be stored

    public float playerAffectedSize;  // Value by which the player will increase/decrease their size when picking up the object 

    public float playerAffectedColliderRadius; //Value by which the player will increase/decrease their collider radius when picking up the object 

    public float cameraDistanceToPlayer; //Value by which the camera will increase/decrease its distance from the player when picking up the object

    public bool Collected;               //Value to keep track if the Object has been collected

    void Start()
    {
        Collected = false;
    }

    void Update()
    {
        if (gameObject.transform.parent == player.transform)
        {
            Collected = true;
        }
        else
        {
            Collected = false;
        }
    }


}
