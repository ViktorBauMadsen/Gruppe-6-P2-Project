using UnityEngine; // Provides access to Unity engine features
using UnityEngine.UI; // Provides access to UI components like Slider
using TMPro; // Provides access to TextMeshPro (not used in this script, but may be used elsewhere)
using UnityEditor; // Provides access to Unity editor features (used for OnValidate)
using UnityEngine.SceneManagement; // Provides access to scene management functions

// This script manages the player's stress value, updates the UI, and handles game over logic.
// It uses a singleton pattern to ensure only one instance exists and persists across scenes.
public class StressValueHolder : MonoBehaviour
{
    public static StressValueHolder singleton; // Singleton instance for global access

    public float StressMeterValue_Max = 100; // Maximum possible stress value
    public float StressMeterValue;           // Current stress value

    public Slider StressMeterSlider;         // Reference to the UI slider that displays stress

    // Called when the script instance is being loaded
    private void Awake()
    {
        // If another instance exists, destroy this one to enforce singleton pattern
        if (singleton != null)
            Destroy(gameObject);
        else
            singleton = this; // Set this as the singleton instance

        DontDestroyOnLoad(gameObject); // Persist this object across scene loads
    }

    // Called in the editor when a value is changed in the inspector
    private void OnValidate()
    {
        UpdateMeterValue(); // Ensure the UI and logic are updated when values change in the editor
    }

    // Reduces the current stress by the specified amount and updates the UI and logic
    public void RemoveStress(float stressRemoval)
    {
        StressMeterValue -= stressRemoval; // Subtract the specified amount from the current stress
        UpdateMeterValue();                // Update the UI and check for limits
    }

    // Increases the current stress by the specified amount and updates the UI and logic
    public void AddStress(float stressAddition)
    {
        StressMeterValue += stressAddition; // Add the specified amount to the current stress
        UpdateMeterValue();                 // Update the UI and check for limits
    }

    // Updates the stress value, clamps it within limits, updates the UI, and checks for effects or game over
    public void UpdateMeterValue()
    {
        // Clamp the stress value between 0 and the maximum allowed
        StressMeterValue = Mathf.Clamp(StressMeterValue, 0, StressMeterValue_Max);

        // Update the slider UI to reflect the current stress as a normalized value (0 to 1)
        StressMeterSlider.value = StressMeterValue / StressMeterValue_Max;

        ProcessingCheck(); // Update post-processing effects based on stress
        DeathCheck();      // Check if the player has reached maximum stress (game over)
    }

    // Updates post-processing visual effects based on the current stress value
    private void ProcessingCheck()
    {
        // Adjusts visual parameters (e.g., blur, color, etc.) based on stress
        ChangePostProcessing.singleton.ChangeParameters(
            StressMeterValue / 250, // Example: intensity or blur
            StressMeterValue / 10,  // Example: color shift or saturation
            StressMeterValue / 2    // Example: vignette or other effect
        );
    }

    // Checks if the stress value has reached the maximum and triggers the death/game over screen if so
    private void DeathCheck()
    {
        if (StressMeterValue >= StressMeterValue_Max)
        {
            SceneManager.LoadScene("DeathScreen"); // Load the "DeathScreen" scene if stress is maxed out
        }
    }
}
