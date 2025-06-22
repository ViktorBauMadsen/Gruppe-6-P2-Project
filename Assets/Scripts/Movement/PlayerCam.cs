using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Controls the player's camera rotation based on mouse movement.
public class PlayerCam : MonoBehaviour
{
    public float sensX; // Mouse sensitivity for horizontal (X axis) movement
    public float sensY; // Mouse sensitivity for vertical (Y axis) movement

    public Transform orientation; // Reference to the player's orientation (usually the player body) for yaw rotation

    float xRotation; // Stores the current vertical rotation (pitch)
    float yRotation; // Stores the current horizontal rotation (yaw)

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Lock the cursor to the center of the screen
        Cursor.visible = false; // Hide the cursor from view
    }

    private void Update()
    {
        // Get raw mouse input for X (horizontal) and Y (vertical) axes
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX; // Horizontal mouse movement, scaled by sensitivity and frame time
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY; // Vertical mouse movement, scaled by sensitivity and frame time

        yRotation += mouseX; // Add horizontal mouse movement to yaw (left/right)
        xRotation -= mouseY; // Subtract vertical mouse movement from pitch (up/down), inverting so up is up

        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // Clamp pitch to prevent the camera from flipping over

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0); // Apply pitch and yaw to the camera's rotation

        orientation.rotation = Quaternion.Euler(0, yRotation, 0); // Apply only yaw to the orientation (player body), so the player turns left/right
    }
}
