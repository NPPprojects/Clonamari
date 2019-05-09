using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniMapCamera : MonoBehaviour {

    public Transform player;

    public float smoothTime = 0.3f;

    private Vector3 offset;
    void Start()
    {
        offset = new Vector3(0, 10.0f, 0);
    }

    void LateUpdate()
    {
        Vector3 playerPos = player.position;
        playerPos.y = transform.position.y;
        transform.position =  Vector3.SmoothDamp(transform.position, playerPos, ref offset, smoothTime);

    }

}
