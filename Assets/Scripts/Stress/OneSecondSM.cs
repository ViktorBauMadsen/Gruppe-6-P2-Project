using UnityEngine; // Provides access to Unity engine features

// This script adds stress to the player at regular time intervals.
// Attach this script to a GameObject to increment stress every 'interval' seconds.
public class OneSecondSM : MonoBehaviour
{
    private float timer = 0f;         // Tracks elapsed time since the last stress increment
    public float interval = 1f;       // How often (in seconds) to add stress

    // Called once per frame by Unity
    void Update()
    {
        timer += Time.deltaTime;      // Add the time since the last frame to the timer

        // If the timer exceeds or equals the interval, add stress and reset the timer
        if (timer >= interval)
        {
            StressValueHolder.singleton.AddStress(2); // Increase the player's stress by 2
            timer = 0f;                               // Reset the timer to start counting again
        }
    }
}
