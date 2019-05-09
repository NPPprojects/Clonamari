using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour 

{
	public GameObject player;
	private Vector3 offset;

	void Start () {
		offset = new Vector3(0, 2.0f, 0);
	}
	
	void LateUpdate () {
        transform.LookAt(player.transform.position + offset);
       
    }
}
