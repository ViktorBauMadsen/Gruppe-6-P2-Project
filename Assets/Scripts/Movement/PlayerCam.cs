using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCam : MonoBehaviour
{
    public float sensX; // Mouse sensitivity on the X axis (horizontal)
    public float sensY; // Mouse sensitivity on the Y axis (vertical)

    public Transform orientation; // Reference to the player's orientation transform (typically controls movement direction)

    float xRotation; // Tracks the current vertical camera rotation
    float yRotation; // Tracks the current horizontal camera rotation

    private void Start()
    {
        // Lock and hide the cursor to keep it centered and invisible during gameplay
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        // Get raw mouse input and scale it by sensitivity and delta time for consistent movement
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.fixedDeltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.fixedDeltaTime * sensY;

        // Adjust horizontal rotation based on mouse X movement
        yRotation += mouseX;

        // Adjust vertical rotation based on mouse Y movement (inverted for natural feel)
        xRotation -= mouseY;
        // Clamp vertical rotation so the player can't over-rotate the camera (look too far up/down)
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        // Apply rotation to the camera (x for up/down, y for left/right)
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        // Apply only horizontal rotation to the player's orientation (used for movement direction)
        orientation.rotation = Quaternion.Euler(0, yRotation, 0);
    }
}
