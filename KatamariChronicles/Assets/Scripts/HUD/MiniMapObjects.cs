using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapObjects : MonoBehaviour {

    public GameObject parent;

    void Update()
    {
        IsCollected();
        Visiblity();
    }

    void IsCollected()
    {
        if (parent.GetComponent<CollectableObjects>().Collected == true)
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().enabled = true;
        }
    }

    void Visiblity()
    {
        if(parent.GetComponent<Collider>().isTrigger == false)
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().color = Color.green;
        }
    }
}
