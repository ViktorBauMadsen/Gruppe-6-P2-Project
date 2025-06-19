using UnityEngine;

public class StressTrigger : MonoBehaviour
{
    // Reference to the StressMeter script attached to the StressManager
    public StressMeter stressMeter;

    // Time-based stress increase settings
    [SerializeField] private float timeBasedStressIncreaseRate = 20f;  // How fast stress increases over time (1 unit per second)
    private float timeSinceLastIncrease = 0f;  // Timer to track how long to wait before increasing stress

    // Settings for answering wrong
    [SerializeField] private float wrongAnswerStressIncrease = 30f;  // How much stress to increase for a wrong answer

    void Update()
    {
        // Time-based stress increase (increase stress every second)
        timeSinceLastIncrease += Time.deltaTime;
        if (timeSinceLastIncrease >= 5f)  // Increase stress every second
        {
            timeSinceLastIncrease = 0f;  // Reset the timer
            IncreaseStressOverTime();  // Increase stress over time
        }
    }

    // Call this when the player answers incorrectly
    public void AnswerWrong()
    {
        stressMeter.IncreaseStress(wrongAnswerStressIncrease);  // Increase stress by a certain amount
    }

    // Function to gradually increase stress over time
    private void IncreaseStressOverTime()
    {
        stressMeter.IncreaseStress(timeBasedStressIncreaseRate);  // Gradually increase stress each second
    }
}
