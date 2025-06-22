using UnityEngine; // Provides access to Unity's core engine features
using UnityEngine.UI; // Provides access to UI components
using TMPro; // Provides access to TextMeshPro for advanced text rendering

// Manages the player's objectives, updates the UI, and handles objective progression
public class ObjectiveManager : MonoBehaviour
{
    public TextMeshProUGUI objectiveText; // Reference to the UI text element that displays the current objective
    private Objective currentObjective; // Stores the currently active objective

    // Called by Unity when the scene starts
    void Start()
    {
        // Create a new GameObject to hold the first objective
        GameObject objectiveGO = new GameObject("Objective");

        // Attach an Objective component to the new GameObject
        Objective objective = objectiveGO.AddComponent<Objective>();

        // Set the description for the first objective
        objective.Initialize("Reduce your stress level");

        // Make this the current objective and update the UI
        SetObjective(objective);
    }

    // Called by Unity every frame
    void Update()
    {
        // Only proceed if there is an active objective
        if (currentObjective != null)
        {
            // Always update the UI text to match the current objective's description
            objectiveText.text = currentObjective.Description;

            // If the current objective is marked as completed
            if (currentObjective.IsCompleted)
            {
                // Create a new GameObject for the next objective
                GameObject objectiveGO = new GameObject("Objective");

                // Attach a new Objective component to it
                Objective objective = objectiveGO.AddComponent<Objective>();

                // Set the description for the next objective
                objective.Initialize("Talk to some students and then the teacher.");

                // Make this the new current objective and update the UI
                SetObjective(objective);
            }
            // If the current objective is the last one in the sequence, you can add more logic here
            else if (currentObjective.Description == "Talk to some students and then the teacher.")
            {
                // Placeholder for future objectives or ending the sequence
            }
        }
    }

    // Sets the current objective and updates the UI
    public void SetObjective(Objective newObjective)
    {
        // Prevent setting a null objective, which would break the logic
        if (newObjective == null)
        {
            Debug.LogError("Attempted to set a null objective!");
            return;
        }

        // Store the new objective as the current one
        currentObjective = newObjective;

        // Update the UI text if the reference is set
        if (objectiveText != null)
        {
            objectiveText.text = currentObjective.Description;
        }

        // Log the new objective for debugging purposes
        Debug.Log("Objective set: " + currentObjective.Description);
    }

    // Marks the current objective as completed, if one exists
    public void CompleteCurrentObjective()
    {
        // Only complete if there is an active objective
        if (currentObjective != null)
        {
            // Call the method to mark the objective as completed
            currentObjective.CompleteObjective();

            // Log the completion for debugging
            Debug.Log("Objective completed: " + currentObjective.Description);
        }
        else
        {
            // Warn if there is no objective to complete
            Debug.LogError("No current objective to complete!");
        }
    }
}