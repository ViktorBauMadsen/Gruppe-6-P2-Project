using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    // Sensitivity values for mouse movement along X and Y axes.
    public float sensX;
    public float sensY;

    // Reference to the orientation object (usually the player body) for horizontal rotation.
    public Transform orientation;

    // Internal variables to store current rotation values.
    float xRotation;
    float yRotation;

    private void Start()
    {
        // Locks the cursor to the center of the screen and makes it invisible.
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        // Get raw mouse input and scale it with sensitivity and frame time.
        // NOTE: Use Time.deltaTime in Update (not fixedDeltaTime).
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        // Accumulate horizontal rotation (yaw).
        yRotation += mouseX;

        // Accumulate vertical rotation (pitch), inverted so that moving mouse up looks up.
        xRotation -= mouseY;

        // Clamp the vertical rotation to avoid flipping the camera over.
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // Apply rotation to the camera (pitch and yaw).
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);

        // Only apply yaw (horizontal rotation) to the orientation object.
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
