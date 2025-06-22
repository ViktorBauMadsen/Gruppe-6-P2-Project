using UnityEngine; // Provides access to Unity engine features
using System.Collections; // Provides support for coroutines (not used in this script, but commonly included)
using System.Collections.Generic; // Provides support for generic collections (not used here)
using UnityEngine.SceneManagement; // Provides access to scene management functions

// This script allows the player to interact with the teacher to trigger a scene change.
// Implements IInteractable so it can be detected and used by the PlayerInteraction system.
public class NextSceneTeaacher : MonoBehaviour, IInteractable // Inherits from MonoBehaviour and implements IInteractable
{
    // Returns a description of the interaction, shown in the UI when the player looks at the teacher
    public string GetDescription()
    {
        return "Talk to Teacher"; // Text displayed to the player in the interaction UI
    }

    // Called when the player interacts with the teacher (e.g., presses 'E')
    public void Interact()
    {
       SceneManager.LoadScene("QuizScene4"); // Loads the scene named "QuizScene4"
    }
}
