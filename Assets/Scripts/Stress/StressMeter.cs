using UnityEngine; // Provides access to Unity engine features
using UnityEngine.UI; // Provides access to UI components like Slider

// This script manages the player's stress level and updates a UI slider to reflect changes.
public class StressMeter : MonoBehaviour
{
    // Adjustable settings for stress behavior
    [SerializeField] private float maxStress = 100f;     // The maximum value the stress can reach
    [SerializeField] private float stressIncrease = 20f; // Amount to increase stress per event
    [SerializeField] private float stressDecrease = 10f; // Amount to decrease stress per second

    [SerializeField] private Slider stressBar; // Reference to the UI Slider that displays stress

    private float stress = 0f; // Current stress value

    // Called by Unity when the script instance is loaded (when the scene starts)
    void Start()
    {
        // Initialize the slider's max value and current value if the slider is assigned
        if (stressBar != null)
        {
            stressBar.maxValue = maxStress; // Set the slider's maximum value
            stressBar.value = stress;       // Set the slider's current value to the starting stress
        }
    }

    // Called once per frame by Unity
    void Update()
    {
        // Gradually decrease stress over time if stress is above zero
        if (stress > 0)
        {
            stress -= stressDecrease * Time.deltaTime; // Reduce stress based on time passed
            stress = Mathf.Clamp(stress, 0, maxStress); // Ensure stress stays within 0 and maxStress
        }

        // Update the UI slider to match the current stress value
        if (stressBar != null)
            stressBar.value = stress;
    }

    // Increases stress by the default stressIncrease amount
    public void AddStress()
    {
        stress += stressIncrease; // Add the default increase amount to stress
        stress = Mathf.Clamp(stress, 0, maxStress); // Clamp stress to valid range
    }

    // Increases stress by a specified amount
    public void IncreaseStress(float amount)
    {
        stress += amount; // Add the specified amount to stress
        stress = Mathf.Clamp(stress, 0, maxStress); // Clamp stress to valid range
    }

    // Decreases stress by the default stressIncrease amount
    public void ReduceStress()
    {
        stress -= stressIncrease; // Subtract the default increase amount from stress
        stress = Mathf.Clamp(stress, 0, maxStress); // Clamp stress to valid range
    }
}