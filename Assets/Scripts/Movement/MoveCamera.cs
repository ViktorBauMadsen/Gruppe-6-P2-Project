using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    // Reference to the target position (typically where the camera should be)
    public Transform cameraPosition;

    void Update()
    {
        // Each frame, move this object (the actual camera) to the position of 'cameraPosition'
        transform.position = cameraPosition.position;
    }
}
