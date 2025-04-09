using UnityEngine;
using UnityEngine.UI;

public class StressMeter : MonoBehaviour
{
    // Adjustable settings for stress behavior
    [SerializeField] private float maxStress = 100f;    // Maximum stress limit
    [SerializeField] private float stressIncrease = 20f; // How much stress increases per event
    [SerializeField] private float stressDecrease = 5f; // How much stress reduces per second

    [SerializeField] private Slider stressBar; // Reference to UI Slider

    private float stress = 0f; // Current stress level

    void Start()
    {
        // Set slider values if assigned
        if (stressBar != null)
        {
            stressBar.maxValue = maxStress;
            stressBar.value = stress;
        }
    }

    void Update()
    {
        // Slowly reduce stress over time
        if (stress > 0)
        {
            stress -= stressDecrease * Time.deltaTime;
            stress = Mathf.Clamp(stress, 0, maxStress); // Keep stress within limits
        }

        // Update UI slider
        if (stressBar != null)
            stressBar.value = stress;
    }

    // Method to manually increase stress
    public void AddStress()
    {
        stress += stressIncrease;
        stress = Mathf.Clamp(stress, 0, maxStress);
    }
    public void IncreaseStress(float amount)
{
    stress += amount;  // Increase the current stress by the specified amount
    stress = Mathf.Clamp(stress, 0, maxStress);  // Ensure stress stays within bounds (0 to maxStress)
}

    // Method to manually decrease stress
    public void ReduceStress()
    {
        stress -= stressIncrease;
        stress = Mathf.Clamp(stress, 0, maxStress);
    }
}
