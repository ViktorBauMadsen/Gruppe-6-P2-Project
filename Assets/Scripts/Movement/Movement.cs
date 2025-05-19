using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Simple first-person character movement and camera control system.

public class Movement : MonoBehaviour
{
    [SerializeField] Transform playerCamera;  // Reference to the player's camera for rotation control

    [SerializeField][Range(0.0f, 0.5f)] float mouseSmoothTime = 0.03f; // Smoothing time for mouse input
    [SerializeField] bool cursorLock = true;                          // Whether the cursor should be locked to the center
    [SerializeField] float mouseSensitivity = 3.5f;                   // Mouse look sensitivity

    [SerializeField] float Speed = 6.0f;                              // Player movement speed
    [SerializeField][Range(0.0f, 0.5f)] float moveSmoothTime = 0.3f;  // Smoothing time for movement input
    [SerializeField] float gravity = -30f;                            // Gravity strength

    [SerializeField] Transform groundCheck;                           // Position to check if player is grounded
    [SerializeField] LayerMask ground;                                // Layers considered as ground

    public float jumpHeight = 6f;     // Height of the jump

    float velocityY;                 // Vertical velocity (used for jumping/falling)
    bool isGrounded;                 // Whether the player is currently grounded

    float cameraCap;                 // Vertical camera rotation clamping value
    Vector2 currentMouseDelta;       // Current smoothed mouse input
    Vector2 currentMouseDeltaVelocity; // Velocity for smoothing mouse input

    CharacterController controller;  // Unity's built-in character controller

    Vector2 currentDir;              // Current smoothed movement direction
    Vector2 currentDirVelocity;      // Velocity for movement smoothing
    Vector3 velocity;                // Final movement vector

    void Start()
    {
        controller = GetComponent<CharacterController>();

        // Lock and optionally hide the cursor if enabled
        if (cursorLock)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;  // Usually you hide the cursor when locking it
        }
    }

    void Update()
    {
        UpdateMouse();  // Handle camera rotation
        UpdateMove();   // Handle player movement
    }

    void UpdateMouse()
    {
        // Get raw mouse input
        Vector2 targetMouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        // Smooth the mouse movement
        currentMouseDelta = Vector2.SmoothDamp(currentMouseDelta, targetMouseDelta, ref currentMouseDeltaVelocity, mouseSmoothTime);

        // Apply vertical rotation with clamping
        cameraCap -= currentMouseDelta.y * mouseSensitivity;
        cameraCap = Mathf.Clamp(cameraCap, -90.0f, 90.0f);

        // Rotate camera up/down (pitch)
        playerCamera.localEulerAngles = Vector3.right * cameraCap;

        // Rotate player left/right (yaw)
        transform.Rotate(Vector3.up * currentMouseDelta.x * mouseSensitivity);
    }

    void UpdateMove()
    {
        // Check if the player is on the ground using a small sphere cast
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.2f, ground);

        // Get movement input (WASD or arrow keys)
        Vector2 targetDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        targetDir.Normalize();  // Ensure consistent speed in all directions

        // Smooth the movement direction
        currentDir = Vector2.SmoothDamp(currentDir, targetDir, ref currentDirVelocity, moveSmoothTime);

        // Apply gravity over time
        velocityY += gravity * 2f * Time.deltaTime;

        // Calculate final velocity vector
        Vector3 velocity = (transform.forward * currentDir.y + transform.right * currentDir.x) * Speed
                         + Vector3.up * velocityY;

        // Move the character
        controller.Move(velocity * Time.deltaTime);

        // Handle jumping
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            // Apply upward force to jump
            velocityY = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // Reset vertical velocity when falling
        if (!isGrounded && controller.velocity.y < -1f)
        {
            velocityY = -8f;
        }
    }
}
