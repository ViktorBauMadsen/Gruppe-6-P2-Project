using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCamera : MonoBehaviour
{
    // Reference to the target position (usually an empty GameObject or another Transform)
    // that the camera should follow or match.
    public Transform cameraPosition;

    void Update()
    {
        // Every frame, update this GameObject's position to match the target's position.
        // This is often used to make the camera follow a player or another object.
        transform.position = cameraPosition.position;
    }
}
