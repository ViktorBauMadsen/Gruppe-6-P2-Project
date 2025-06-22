using UnityEngine; // Provides access to Unity engine features

// Represents a single objective in the game, with a description and completion state
public class Objective : MonoBehaviour
{
    public string Description { get; private set; } // The text description of the objective (readable publicly, settable only within this class)
    public bool IsCompleted { get; private set; }   // Indicates whether the objective has been completed (readable publicly, settable only within this class)

    // Initializes the objective with a description and marks it as not completed
    public void Initialize(string description)
    {
        Description = description; // Set the objective's description
        IsCompleted = false;       // Mark the objective as not completed
    }

    // Marks the objective as completed
    public void CompleteObjective()
    {
        IsCompleted = true; // Set the completion state to true
    }
}
