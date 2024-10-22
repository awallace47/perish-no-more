using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject followObject;
    float z;

    private void Start()
    {
        z = transform.position.z;

        SetCameraPosition();
    }

    void FixedUpdate()
    {
        if (followObject == null) return;

        SetCameraPosition();
    }

    void SetCameraPosition()
    {
        float x = followObject.transform.position.x;
        float y = followObject.transform.position.y;

        transform.position = new Vector3(x, y, z);
    }
}
