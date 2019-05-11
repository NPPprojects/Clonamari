using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviewWindow : MonoBehaviour {

    public Transform Object;
    public bool Active;
    Bounds bounds;
    Camera previewCamera;

    void Start()
    {
        previewCamera = gameObject.GetComponent<Camera>(); 
    }
    void LateUpdate()
    {
        if (Active == true)
        {
            LookAtNewObject();
        }
    }

    void LookAtNewObject()
    {    
        bounds = Object.GetChild(0).GetComponent<Renderer>().bounds;
        Vector3 center = bounds.center;
        Vector3 extents = bounds.extents;
        float extentsTotal = extents.x + extents.z + extents.y;
        transform.position = new Vector3(center.x, center.y, center.z-5);
        previewCamera.fieldOfView = extentsTotal*15;
        Active = false;
    }
}
