using UnityEngine; // Provides access to Unity engine features
using TMPro; // Provides access to TextMeshPro UI components

// Handles player interaction with objects in the scene that implement IInteractable
public class PlayerInteraction : MonoBehaviour
{
    public Camera mainCam; // Reference to the main camera used for raycasting (usually the player's camera)
    public float interactDistance = 2f; // Maximum distance at which the player can interact with objects

    public GameObject interactionUI; // UI element that shows when an interactable object is in view
    public TextMeshProUGUI interactionText; // Text element to display the description of the interactable object

    private void Update() // Called once per frame by Unity
    {
        InteractionRay(); // Check for interactable objects every frame
    }

    // Casts a ray from the center of the screen to detect interactable objects
    void InteractionRay()
    {
        // Create a ray from the center of the camera's viewport (screen center)
        Ray ray = mainCam.ViewportPointToRay(Vector3.one / 2f);
        RaycastHit hit; // Stores information about what the ray hits

        bool hitSomething = false; // Tracks if an interactable object was detected

        // Cast the ray forward up to interactDistance units
        if (Physics.Raycast(ray, out hit, interactDistance))
        {
            // Try to get an IInteractable component from the hit object
            IInteractable interactable = hit.collider.GetComponent<IInteractable>();

            // If the object implements IInteractable
            if (interactable != null)
            {
                hitSomething = true; // Mark that we found something interactable

                // Show the object's interaction description in the UI
                interactionText.text = interactable.GetDescription();

                // If the player presses the 'E' key, trigger the interaction
                if (Input.GetKeyDown(KeyCode.E))
                {
                    interactable.Interact();
                }
            }
        }
        // Show or hide the interaction UI based on whether an interactable object is in view
        interactionUI.SetActive(hitSomething);
    }
}
