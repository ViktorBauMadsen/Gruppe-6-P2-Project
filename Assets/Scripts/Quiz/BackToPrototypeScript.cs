using UnityEngine; // Provides access to Unity engine features
using UnityEngine.SceneManagement; // Provides access to scene management functions

// This script allows returning to the "Prototype" scene and manages cursor visibility and locking.
public class BackToPrototype : MonoBehaviour
{
    // Called by Unity when the script instance is being loaded (when the scene starts)
    private void Start()
    {
        Cursor.visible = true; // Make the cursor visible so the user can interact with UI elements
        Cursor.lockState = CursorLockMode.Confined; // Confine the cursor to the game window
    }

    // Loads the scene named "Prototype" when called (e.g., from a UI button)
    // The parameter 'zog' is unused but allows this method to be used with Unity UI events that pass an int
    public void LoadSceneByIndex(int zog)
    {
        SceneManager.LoadScene("Prototype"); // Load the scene called "Prototype"
    }
}
