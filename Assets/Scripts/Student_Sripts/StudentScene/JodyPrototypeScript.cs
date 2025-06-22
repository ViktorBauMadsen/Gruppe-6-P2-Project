using UnityEngine; // Provides access to Unity engine features
using UnityEngine.SceneManagement; // Provides access to scene management functions

// This script is used to manage cursor settings and load the "JodyPrototype" scene.
// Typically attached to a UI button or menu object.
public class JodyPrototypeScript : MonoBehaviour
{
    // Called by Unity when the script instance is loaded (when the scene starts)
    private void Start()
    {
        Cursor.visible = true; // Make the cursor visible so the user can interact with UI elements
        Cursor.lockState = CursorLockMode.Confined; // Confine the cursor to the game window
    }

    // Loads the scene named "JodyPrototype" when called (e.g., from a UI button)
    // The parameter 'zog' is unused but allows this method to be used with Unity UI events that pass an int
    public void LoadSceneByIndex(int zog)
    {
        SceneManager.LoadScene("JodyPrototype"); // Load the scene called "JodyPrototype"
    }
}
