using UnityEngine; // Provides access to Unity engine features
using UnityEngine.SceneManagement; // Provides access to scene management functions

// This script is used for a UI button that returns the player to a specified scene and resets stress.
public class BackToStart_Button : MonoBehaviour
{
    // Called by Unity when the script instance is loaded (when the scene starts)
    private void Start()
    {
        Cursor.visible = true; // Make the cursor visible so the user can interact with UI elements
        Cursor.lockState = CursorLockMode.Confined; // Confine the cursor to the game window
    }

    // Loads a scene by its build index and resets the player's stress value
    // The parameter 'zog' is the build index of the scene to load (set in the UI button)
    public void LoadSceneByIndex(int zog)
    {
        SceneManager.LoadScene(zog); // Load the scene with the specified build index
        // Reset the player's stress by removing the current stress value (sets it to zero)
        StressValueHolder.singleton.RemoveStress(StressValueHolder.singleton.StressMeterValue);
    }
}
