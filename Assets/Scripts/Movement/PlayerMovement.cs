using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;          // How fast the player moves
    public float groundDrag;         // Drag applied when the player is on the ground

    public float jumpForce;          // Force applied when jumping
    public float jumpCooldown;       // Cooldown time before the player can jump again
    public float airMultiplier;      // Multiplier for movement control while in air
    bool readyToJump;                // Whether the player is allowed to jump

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space;  // Key used for jumping

    [Header("Ground Check")]
    public float playerHeight;       // Height used to determine ground distance
    public LayerMask whatIsGround;   // Layer mask used to detect what counts as ground
    bool grounded;                   // Whether the player is currently grounded

    public Transform orientation;    // Reference direction for movement (typically the player’s view or body)

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;           // Direction the player should move

    Rigidbody rb;                    // Rigidbody component for physics-based movement

    private void Start()
    {
        rb = GetComponent<Rigidbody>();   // Get the Rigidbody component
        rb.freezeRotation = true;         // Prevent unwanted rotation due to physics
        readyToJump = true;               // Player starts ready to jump
    }

    private void Update()
    {
        // Check if the player is grounded using a raycast downwards
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

        MyInput(); // Handle input

        // Apply drag if on ground, remove drag if in air
        if (grounded)
            rb.linearDamping = groundDrag;
        else
            rb.linearDamping = 0;
    }

    private void FixedUpdate()
    {
        MovePlayer(); // Handle movement using physics
    }

    private void MyInput()
    {
        // Get movement input from keyboard
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");

        // Handle jumping
        if (Input.GetKey(jumpKey) && readyToJump && grounded)
        {
            readyToJump = false;
            Jump(); // Perform the jump
            Invoke(nameof(ResetJump), jumpCooldown); // Allow jumping again after cooldown
        }
    }

    private void MovePlayer()
    {
        // Calculate movement direction relative to orientation
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        // Apply force based on whether grounded or in air
        if (grounded)
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        else
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
    }

    private void Jump()
    {
        // Reset vertical velocity before jumping to prevent stacking jump force
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

        // Add upward force to jump
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    private void ResetJump()
    {
        readyToJump = true; // Allow jumping again
    }
}
