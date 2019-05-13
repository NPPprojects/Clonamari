using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapObjects : MonoBehaviour {

      GameObject parent;

    void Start()
    {
        parent = transform.parent.gameObject;
    }
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
