using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;

    void Start()
    {
        if (target != null)
        {
            transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
            Debug.Log("Camera initialized at position: " + transform.position);
        }
        else
        {
            Debug.LogError("Target not assigned to the CameraMovement script.");
        }
    }

    void LateUpdate()
    {
        if (target == null)
        {
            Debug.LogError("Target is missing. Cannot move camera.");
            return;
        }

        // Directly set the camera's position to the target's position
        transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
        Debug.Log("Camera moved to position: " + transform.position);
    }
}
