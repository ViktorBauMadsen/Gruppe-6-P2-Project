using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Character movement and camera control script for a first-person controller

public class Movement : MonoBehaviour
{
    [SerializeField] Transform playerCamera; // Reference to the player's camera transform
    [SerializeField][Range(0.0f, 0.5f)] float mouseSmoothTime = 0.03f; // Smoothing time for mouse input
    [SerializeField] bool cursorLock = true; // Whether to lock the mouse cursor
    [SerializeField] float mouseSensitivity = 3.5f; // Mouse sensitivity multiplier
    [SerializeField] float Speed = 6.0f; // Movement speed
    [SerializeField][Range(0.0f, 0.5f)] float moveSmoothTime = 0.3f; // Smoothing time for movement input
    [SerializeField] float gravity = -30f; // Gravity strength
    [SerializeField] Transform groundCheck; // Point from which to check if grounded
    [SerializeField] LayerMask ground; // Layer mask to define what counts as ground

    public float jumpHeight = 6f; // How high the player jumps
    float velocityY; // Vertical velocity affected by gravity
    bool isGrounded; // Whether the player is touching the ground

    float cameraCap; // Clamp value to prevent camera from over-rotating vertically
    Vector2 currentMouseDelta; // Smoothed mouse delta
    Vector2 currentMouseDeltaVelocity; // Velocity used for smoothing mouse delta

    CharacterController controller; // Unity's CharacterController for movement
    Vector2 currentDir; // Current movement direction (smoothed)
    Vector2 currentDirVelocity; // Velocity used for smoothing movement direction
    Vector3 velocity; // Combined velocity for movement

    void Start()
    {
        controller = GetComponent<CharacterController>(); // Get the CharacterController component

        // Lock the cursor for gameplay
        if (cursorLock)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = true; // (Should probably be false for most games)
        }
    }

    void Update()
    {
        UpdateMouse(); // Handle camera look
        UpdateMove();  // Handle movement
    }

    void UpdateMouse()
    {
        // Get raw mouse input
        Vector2 targetMouseDelta = new Vector2(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));

        // Smooth the mouse input
        currentMouseDelta = Vector2.SmoothDamp(currentMouseDelta, targetMouseDelta, ref currentMouseDeltaVelocity, mouseSmoothTime);

        // Adjust camera's vertical angle
        cameraCap -= currentMouseDelta.y * mouseSensitivity;
        cameraCap = Mathf.Clamp(cameraCap, -90.0f, 90.0f); // Clamp to prevent flipping over

        // Apply vertical rotation to the camera
        playerCamera.localEulerAngles = Vector3.right * cameraCap;

        // Apply horizontal rotation to the player
        transform.Rotate(Vector3.up * currentMouseDelta.x * mouseSensitivity);
    }

    void UpdateMove()
    {
        // Check if the player is grounded using a small sphere
        isGrounded = Physics.CheckSphere(groundCheck.position, 0.2f, ground);

        // Get movement input
        Vector2 targetDir = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        targetDir.Normalize(); // Ensure diagonal movement isn't faster

        // Smooth the input for better control
        currentDir = Vector2.SmoothDamp(currentDir, targetDir, ref currentDirVelocity, moveSmoothTime);

        // Apply gravity over time
        velocityY += gravity * 2f * Time.deltaTime;

        // Calculate full movement vector
        Vector3 velocity = (transform.forward * currentDir.y + transform.right * currentDir.x) * Speed + Vector3.up * velocityY;

        // Apply movement using CharacterController
        controller.Move(velocity * Time.deltaTime);

        // Jumping logic
        if (isGrounded && Input.GetButtonDown("Jump"))
        {
            velocityY = Mathf.Sqrt(jumpHeight * -2f * gravity); // Calculate jump velocity based on gravity and jump height
        }

        // Apply a small downward force to keep player grounded when falling
        if (isGrounded && controller.velocity.y < -1f)
        {
            velocityY = -8f;
        }
    }
}
