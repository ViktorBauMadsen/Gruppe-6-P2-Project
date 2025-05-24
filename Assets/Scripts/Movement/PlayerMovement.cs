using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;          // Player movement speed
    public float groundDrag;         // Drag applied when grounded

    public float jumpForce;          // Force applied when jumping
    public float jumpCooldown;       // Time before player can jump again
    public float airMultiplier;      // Movement multiplier while in air
    bool readyToJump;                // Controls whether the player can jump

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space; // Jump input key

    [Header("Ground Check")]
    public float playerHeight;       // Height of the player (used for ground check raycast)
    public LayerMask whatIsGround;   // Layer(s) considered as ground
    bool grounded;                   // Is the player currently grounded?

    public Transform orientation;    // Reference for directional movement (usually the player's facing direction)

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;

    private void Start()
    {
        // Get the Rigidbody component and prevent unwanted rotation from physics
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;

        // Allow jumping at the start
        readyToJump = true;
    }

    private void Update()
    {
        // Check if the player is grounded using a raycast
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

        MyInput();

        // Apply ground drag if grounded; else set to 0 for free movement in air
        rb.linearDamping = grounded ? groundDrag : 0f;
    }

    private void FixedUpdate()
    {
        // Handle movement using physics
        MovePlayer();
    }

    private void MyInput()
    {
        // Get WASD or arrow key input
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        // Check for jump input
        if (Input.GetKey(jumpKey) && readyToJump && grounded)
        {
            readyToJump = false;

            Jump();

            // Reset jump after cooldown time
            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }

    private void MovePlayer()
    {
        // Calculate movement direction relative to player orientation
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        // Apply force based on whether grounded or in air
        if (grounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        }
        else
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
        }
    }

    private void Jump()
    {
        // Reset vertical velocity before jump for consistent height
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

        // Apply an upward impulse force to jump
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void ResetJump()
    {
        // Re-enable jumping after cooldown
        readyToJump = true;
    }
}
