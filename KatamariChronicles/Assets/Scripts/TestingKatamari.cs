using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
public class TestingKatamari : MonoBehaviour
{
    public float FacingAngle;
    public float rotationSpeed;
    public float verticalSpeed;
    public float playerSpeed;     //Keeps track of the speed of the player
    public float playerSpeedLimit;      //Value of how fast the player can go before the game punishes for crashing
    public float size;
    //Catergoies in which objects will be stored
    //Based on player size, new Categories will be enabled allowing for the player to pick up objects within them

    public GameObject ground;
    
    public GameObject[] category;
    bool[] categoryUnlock;
    public float[] categorySizeRequirement;                 //Size requirment the player has to achive before the next category unlocks 

    public List<GameObject> CollectedGameObjectList;          //List of items the player has collected
    public int totalCollected = 6;             //Starts from six as there are node objects attached to the player that shouldn't be removed

    float x;
    float z;


    // public float timer = 2.0f;          // for when unloading items


    //Translating Angle into unit Vector to face direction with XY components
    Vector2 UnitV2;
    //keeping track of last location to determine speed
    Vector3 lastPosition = Vector3.zero;

    public GameObject cameraObject;
    float distanceToCamera;

    void Start()
    {
        x = 0;
        z = 0;
        categoryUnlock = new bool[category.Length];
        distanceToCamera = 5;
    }
    void Update()
    {
        //Controls
        x = Input.GetAxis("Horizontal") * Time.deltaTime * -rotationSpeed;
        z = Input.GetAxis("Vertical") * Time.deltaTime * verticalSpeed;

        //Facing Angle
        FacingAngle += x;
        //Apply Force to ball and position Camera
        UnitV2 = new Vector2(Mathf.Cos(FacingAngle * Mathf.Deg2Rad), Mathf.Sin(FacingAngle * Mathf.Deg2Rad));

        unlockStickyCategories();

        //Detect Player Speed

        playerSpeed = (transform.position - lastPosition).magnitude * 100;
        lastPosition = transform.position;

        // Mathf.Abs() which should return the absolute value of a float is not working
        if (size < 0)
        {
            size = 0;
        }

    }

    private void FixedUpdate()        // Physics Updates
    {
        //Apply Force on the Ball
        this.transform.GetComponent<Rigidbody>().AddForce(new Vector3(UnitV2.x, 0, UnitV2.y) * z * 3);

    }
    private void LateUpdate()                   //Prevent Camera from jittering
    {
        //Set Camera position to be behind the ball based on rotation 

        cameraObject.transform.position = new Vector3(-UnitV2.x * distanceToCamera, distanceToCamera, -UnitV2.y * distanceToCamera) + gameObject.transform.position;
    }

    void unlockStickyCategories()
    {
        for (int i = 0; i < category.Length; i++) //Goes throught every category
            if (categoryUnlock[i] == false)
            {
                if (size >= categorySizeRequirement[i])
                {
                    categoryUnlock[i] = true;
                    for (int y = 0; y < category[i].transform.childCount; y++) // Goes through every child of the category
                    {
                        category[i].transform.GetChild(y).GetComponent<FixedJoint>().connectedBody = null;
                    }
                }
                if (size < categorySizeRequirement[i])
                {
                    categoryUnlock[i] = false;
                    for (int y = 0; y < category[i].transform.childCount; y++) // Goes through every child of the category
                    {
                //        category[i].transform.GetChild(y).GetComponent<FixedJoint>().connectedBody = ground.GetComponent<Rigidbody>();
                    }
                }
            }
    }

    //Here comes the Katamari ;)
    void OnTriggerEnter(Collider other)
    {

        if (other.transform.CompareTag("Sticky"))

            other.gameObject.GetComponent<CollectableObjects>();
        transform.localScale += other.gameObject.GetComponent<CollectableObjects>().playerAffectedScale;
        size += other.gameObject.GetComponent<CollectableObjects>().playerAffectedSize;
        distanceToCamera += other.gameObject.GetComponent<CollectableObjects>().cameraDistanceToPlayer;

        //Only ball will pick up objects
        other.isTrigger = false;
        other.enabled = false;

        //Stay a child
        other.transform.SetParent(gameObject.transform);
        //Add to gameObjectList
        CollectedGameObjectList.Add(other.gameObject);
        //Count of Objects collected
        totalCollected++;




    }

    void OnCollisionEnter(Collision other)
    {

        if (other.transform.CompareTag("Sticky") && (other.gameObject.GetComponent<FixedJoint>().connectedBody==null))
        {
            other.gameObject.GetComponent<FixedJoint>().connectedBody = gameObject.GetComponent<Rigidbody>();
            other.gameObject.GetComponent<Rigidbody>().useGravity = false;
        }

    }
}


