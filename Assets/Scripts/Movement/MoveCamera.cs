using System.Collections; // Provides support for non-generic collections (not used in this script)
using System.Collections.Generic; // Provides support for generic collections (not used here)
using UnityEngine; // Provides access to Unity engine features

// This script moves the camera to follow a target position every frame.
// Attach this script to the camera GameObject and assign a target Transform in the inspector.
public class MoveCamera : MonoBehaviour
{
    // Reference to the target Transform that the camera should follow.
    // This is usually set to the player, another object, or an empty GameObject in the scene.
    public Transform cameraPosition;

    // Called once per frame by Unity
    void Update()
    {
        // Set this GameObject's position to match the target's position every frame.
        // This makes the camera follow the assigned target smoothly and exactly.
        transform.position = cameraPosition.position;
    }
}
