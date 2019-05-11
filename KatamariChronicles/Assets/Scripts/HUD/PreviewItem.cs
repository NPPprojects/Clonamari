using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviewItem : MonoBehaviour {

    public GameObject player;
    int LastItem;
    float destroyTimer=2.0f;
    bool secondDeath;
    public bool previewState;
    void Start()
    {
        previewState = false;
       
    }
    void Update()
    {

        transform.Rotate(new Vector3(0, -45, 0) * Time.deltaTime);
        PreviewNewestItem();
      

    }
    void PreviewNewestItem()
    {
        
        if (previewState == true)
        {
            LastItem = player.GetComponent<PlayerController>().CollectedGameObjectList.Count - 1;
          
            GameObject clone = Instantiate(player.GetComponent<PlayerController>().CollectedGameObjectList[LastItem], transform.position, transform.rotation,transform);
 
         
            gameObject.transform.eulerAngles = new Vector3(0, 0, 0);
            DestroyObject(clone);
            previewState = false;
          
        }

    }
    void DestroyObject(GameObject clone)
    {
        Destroy(clone, destroyTimer);
        if (transform.childCount == 2)
        {
           Destroy(transform.GetChild(0).gameObject);
        }
    }


}

