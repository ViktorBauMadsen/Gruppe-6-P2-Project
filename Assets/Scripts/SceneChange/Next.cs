using UnityEngine; // Provides access to Unity engine features
using UnityEngine.UI; // Provides access to UI components (not used directly in this script, but may be used if attached to a UI button)
using UnityEngine.SceneManagement; // Provides access to scene management functions

// This script is used to load the next scene in the build order.
// Typically attached to a UI button to advance to the next scene when clicked.
public class Next : MonoBehaviour
{
    // Called by Unity when the script instance is loaded (not used here, but included for completeness)
    void Start()
    {
    }

    // Loads the next scene in the build index when called (e.g., from a UI button)
    public void ChangeScene()
    {
        // Get the current scene's build index and load the next scene in the build order
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}