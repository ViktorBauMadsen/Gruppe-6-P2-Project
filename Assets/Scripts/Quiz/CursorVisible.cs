using UnityEngine; // Provides access to Unity engine features

// This script ensures the mouse cursor is visible and unlocked when the scene starts.
// Attach this script to any GameObject in a scene where you want the cursor to be visible.
public class CursorVisible : MonoBehaviour
{
    // Called by Unity when the script instance is loaded (when the scene starts)
    void Start()
    {
        Cursor.lockState = CursorLockMode.None; // Unlock the cursor so it can move freely
        Cursor.visible = true;                  // Make the cursor visible on the screen
    }

    // Update is called once per frame by Unity (not used in this script)
    void Update()
    {
        // No logic needed here for cursor visibility
    }
}
