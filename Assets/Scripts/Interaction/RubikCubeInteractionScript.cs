using UnityEngine; // Provides access to Unity engine features

// This script allows the player to interact with a Rubik's Cube object in the scene.
// Implements IInteractable so it can be detected and used by the PlayerInteraction system.
public class RubikCubeInteractionScript : MonoBehaviour, IInteractable // Inherits from MonoBehaviour and implements IInteractable
{
    // Returns a description of the interaction, shown in the UI when the player looks at the Rubik's Cube
    public string GetDescription()
    {
        return "Use Rubiks Cube"; // Text displayed to the player in the interaction UI
    }

    // Called when the player interacts with the Rubik's Cube (e.g., presses 'E')
    public void Interact()
    {
        StressValueHolder.singleton.RemoveStress(20); // Reduces the player's stress by 20 using the StressValueHolder singleton
    }
}
