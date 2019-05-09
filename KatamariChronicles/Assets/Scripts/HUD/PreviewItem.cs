using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviewItem : MonoBehaviour {

    public GameObject player;
    int LastItem;
    void Update()
    {

      transform.Rotate(new Vector3(0, -45, 0) * Time.deltaTime);
    //    PreviewNewestItem();
    }
    void PreviewNewestItem()
    {
        LastItem = player.GetComponent<PlayerController>().CollectedGameObjectList.Count - 1;
        Instantiate(player.GetComponent<PlayerController>().CollectedGameObjectList[LastItem], transform.position, transform.rotation);

    }
}

