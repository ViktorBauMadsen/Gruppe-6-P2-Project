using UnityEngine; // Provides access to Unity engine features

// Handles player movement, jumping, and ground detection using Rigidbody physics.
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;          // Player movement speed
    public float groundDrag;         // Drag applied to the Rigidbody when grounded

    public float jumpForce;          // Upward force applied when jumping
    public float jumpCooldown;       // Time (in seconds) before the player can jump again
    public float airMultiplier;      // Multiplier for movement speed while in the air
    bool readyToJump;                // Whether the player is allowed to jump

    [Header("Keybinds")]
    public KeyCode jumpKey = KeyCode.Space; // Key used to trigger a jump

    [Header("Ground Check")]
    public float playerHeight;       // Height of the player, used for ground check raycast length
    public LayerMask whatIsGround;   // Layer(s) considered as ground for collision checks
    bool grounded;                   // Is the player currently on the ground?

    public Transform orientation;    // Reference for movement direction (usually the player's facing direction)

    float horizontalInput;           // Stores horizontal input value (A/D or Left/Right arrow)
    float verticalInput;             // Stores vertical input value (W/S or Up/Down arrow)

    Vector3 moveDirection;           // The direction the player should move in

    Rigidbody rb;                    // Reference to the Rigidbody component for physics-based movement

    private void Start()
    {
        rb = GetComponent<Rigidbody>(); // Get the Rigidbody component attached to this GameObject
        rb.freezeRotation = true;       // Prevent the Rigidbody from rotating due to physics

        readyToJump = true;             // Allow jumping at the start of the game
    }

    private void Update()
    {
        // Check if the player is grounded by casting a ray downward from the player's position
        grounded = Physics.Raycast(
            transform.position,         // Start at the player's position
            Vector3.down,               // Cast straight down
            playerHeight * 0.5f + 0.2f, // Ray length: half the player's height plus a small buffer
            whatIsGround                // Only detect objects on the ground layer(s)
        );

        MyInput(); // Handle player input for movement and jumping

        // Apply ground drag if grounded, otherwise set drag to 0 for smooth air movement
        rb.linearDamping = grounded ? groundDrag : 0f;
    }

    private void FixedUpdate()
    {
        MovePlayer(); // Handle movement using physics in FixedUpdate for consistent results
    }

    // Handles input for movement and jumping
    private void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal"); // Get horizontal input (A/D or Left/Right arrow)
        verticalInput = Input.GetAxisRaw("Vertical");     // Get vertical input (W/S or Up/Down arrow)

        // Check if jump key is pressed, player is ready to jump, and is grounded
        if (Input.GetKey(jumpKey) && readyToJump && grounded)
        {
            readyToJump = false; // Prevent jumping again until cooldown

            Jump(); // Perform the jump

            // Reset jump ability after the cooldown period
            Invoke(nameof(ResetJump), jumpCooldown);
        }
    }

    // Applies movement forces to the Rigidbody
    private void MovePlayer()
    {
        // Calculate movement direction based on orientation and input
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        // If grounded, apply normal movement force
        if (grounded)
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
        }
        // If in the air, apply reduced movement force
        else
        {
            rb.AddForce(moveDirection.normalized * moveSpeed * 10f * airMultiplier, ForceMode.Force);
        }
    }

    // Handles the jump action
    private void Jump()
    {
        // Reset vertical velocity to zero before jumping for consistent jump height
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0f, rb.linearVelocity.z);

        // Apply an upward impulse to make the player jump
        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
    }

    // Resets the ability to jump after the cooldown
    private void ResetJump()
    {
        readyToJump = true; // Allow the player to jump again
    }
}
