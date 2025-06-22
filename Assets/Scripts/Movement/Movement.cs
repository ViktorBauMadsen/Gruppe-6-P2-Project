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

    float cameraCap;                 // Vertical camera rotation clamping value (prevents over-rotation)
    Vector2 currentMouseDelta;       // Current smoothed mouse input
    Vector2 currentMouseDeltaVelocity; // Velocity for smoothing mouse input

    CharacterController controller;  // Unity's built-in character controller

    Vector2 currentDir;              // Current smoothed movement direction
    Vector2 currentDirVelocity;      // Velocity for movement smoothing
    Vector3 velocity;                // Final movement vector

    // Called once at the start of the game
    void Start()
    {
        controller = GetComponent<CharacterController>(); // Get the CharacterController component attached to this GameObject

        // Lock and optionally hide the cursor if enabled
        if (cursorLock)
        {
            Cursor.lockState = CursorLockMode.Locked; // Lock the cursor to the center of the screen
            Cursor.visible = false;  // Hide the cursor
        }
    }

    // Called once per frame by Unity
    void Update()
    {
        UpdateMouse();  // Handle camera rotation based on mouse movement
        UpdateMove();   // Handle player movement and jumping
    }

    // Handles mouse input and rotates the camera/player accordingly
    void UpdateMouse()
    {
        // Get raw mouse input (X = left/right, Y = up/down)
        Vector2 targetMouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        // Smooth the mouse movement for a less jittery experience
        currentMouseDelta = Vector2.SmoothDamp(currentMouseDelta, targetMouseDelta, ref currentMouseDeltaVelocity, mouseSmoothTime);

        // Adjust vertical camera rotation (pitch), clamped to prevent flipping
        cameraCap -= currentMouseDelta.y * mouseSensitivity;
        cameraCap = Mathf.Clamp(cameraCap, -90.0f, 90.0f);

        // Apply vertical rotation to the camera (look up/down)
        playerCamera.localEulerAngles = Vector3.right * cameraCap;

        // Apply horizontal rotation to the player (turn left/right)
        transform.Rotate(Vector3.up * currentMouseDelta.x * mouseSensitivity);
    }

    // Handles player movement, jumping, and gravity
    void UpdateMove()
    {
        // Check if the player is on the ground using a small sphere at the groundCheck position
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.2f, ground);

        // Get movement input from keyboard (WASD or arrow keys)
        Vector2 targetDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        targetDir.Normalize();  // Normalize to ensure consistent speed in all directions

        // Smooth the movement direction for more natural acceleration/deceleration
        currentDir = Vector2.SmoothDamp(currentDir, targetDir, ref currentDirVelocity, moveSmoothTime);

        // Apply gravity to the vertical velocity
        velocityY += gravity * 2f * Time.deltaTime;

        // Calculate the final movement vector (forward/backward, left/right, and up/down)
        Vector3 velocity = (transform.forward * currentDir.y + transform.right * currentDir.x) * Speed
                         + Vector3.up * velocityY;

        // Move the character using the CharacterController
        controller.Move(velocity * Time.deltaTime);

        // Handle jumping: if grounded and jump button pressed, set upward velocity
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            velocityY = Mathf.Sqrt(jumpHeight * -2f * gravity); // Calculate jump velocity using physics formula
        }

        // If falling and not grounded, limit downward velocity for better control
        if (!isGrounded && controller.velocity.y < -1f)
        {
            velocityY = -8f;
        }
    }
}
