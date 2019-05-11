using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PreviewItemName : MonoBehaviour {
    public GameObject player;
    public GameObject previewItem;
    string objectName;
    float timer;
    int LastItem;
    bool DeleteName;

    void Start()
    {
        
    }

    void Update()
    {


        PreviewNewestItem();

        if (DeleteName == true)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                this.GetComponent<Text>().text = null;
                DeleteName = false;
            }
        }
    }

    void PreviewNewestItem()
    {
        
        if (previewItem.GetComponent<PreviewItem>().previewState == true)
        {
            LastItem = player.GetComponent<PlayerController>().CollectedGameObjectList.Count - 1;
            objectName = player.GetComponent<PlayerController>().CollectedGameObjectList[LastItem].gameObject.name;
            this.GetComponent<Text>().text = objectName;
            timer = 2;
            DeleteName = true;

        }
        
    }
}
