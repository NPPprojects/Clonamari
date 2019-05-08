using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableObjects : MonoBehaviour {

    public GameObject player; //

    public Transform category; // Default category in which the object will be stored

    public float playerAffectedSize;  // Value by which the player will increase/decrease their size when picking up the object 

    public Vector3 playerAffectedScale; //Value by which the player will increase/decrease their scale when picking up the object 

    public float cameraDistanceToPlayer; //Value by which the camera will increase/decrease its distance from the player when picking up the object

    
}


