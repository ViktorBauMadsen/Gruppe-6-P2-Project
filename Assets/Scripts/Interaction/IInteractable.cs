using UnityEngine; // Provides access to Unity engine features

// Interface for objects that can be detected and interacted with by the PlayerInteraction system
public interface IInteractable
{
    // Called when the player presses the interact key (e.g., 'E') while looking at this object
    void Interact();

    // Returns a short description to display in the interaction UI when the player looks at this object
    string GetDescription();
}
