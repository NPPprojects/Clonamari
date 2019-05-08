using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundScript : MonoBehaviour {
    
  

    // Use this for initialization
    void Start () {
   
	}
	
	// Update is called once per frame
	void Update ()
    {
        
		
	}
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Sticky"))
        {
            other.gameObject.GetComponent<Collider>().isTrigger = true;
            other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            other.gameObject.GetComponent<Rigidbody>().useGravity = false;

        }
    }


}

