using UnityEngine; // Provides access to Unity engine features

// This script allows the player to interact with headphones in the scene.
// When interacted with, it reduces the player's stress value.
public class HeadPhonesInteractScript : MonoBehaviour, IInteractable // Inherits from MonoBehaviour and implements IInteractable for interaction support
{
    // Returns a description of the interaction, shown in the UI when the player looks at the headphones
    public string GetDescription()
    {
        return "Use Headphones"; // Text displayed to the player in the interaction UI
    }

    // Called when the player interacts with the headphones (e.g., presses 'E')
    public void Interact()
    {
        StressValueHolder.singleton.RemoveStress(20); // Reduces the player's stress by 20 using the StressValueHolder singleton
    }
}
