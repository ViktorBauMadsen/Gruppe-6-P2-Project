using UnityEngine;
using UnityEngine.UI;
using TMPro;


// This class manages objectives in the game, including their creation, updating, and completion
public class ObjectiveManager : MonoBehaviour
{
    public TextMeshProUGUI objectiveText; // Reference to the TextMeshProUGUI component to display the objective text in the UI
    private Objective currentObjective; // Holds the current active objective

    // Start is called before the first frame update
    void Start()
    {
        // Create a new GameObject to represent the first objective
        GameObject objectiveGO = new GameObject("Objective");

        // Add the Objective component to the newly created GameObject
        Objective objective = objectiveGO.AddComponent<Objective>();

        // Initialize the objective with a description
        objective.Initialize("Reduce your stress level");

        // Set the newly created objective as the current objective
        SetObjective(objective);
    }

    // Update is called once per frame
    void Update()
    {
        // Check if there is a current objective
        if (currentObjective != null)
        {
            // Update the UI text to display the current objective's description
            objectiveText.text = currentObjective.Description;

            // Check if the current objective has been completed
            if (currentObjective.IsCompleted)
            {
                // Create a new GameObject for the next objective
                GameObject objectiveGO = new GameObject("Objective");

                // Add the Objective component to the new GameObject
                Objective objective = objectiveGO.AddComponent<Objective>();

                // Initialize the next objective with a new description
                objective.Initialize("Talk to some students and then the teacher.");

                // Set the new objective as the current objective
                SetObjective(objective);
            }
            else if (currentObjective.Description == "Talk to some students and then the teacher.")
            {
                // Placeholder for adding further objectives or ending the objective sequence
            }
        }
    }

    // Sets the current objective to a new objective
    public void SetObjective(Objective newObjective)
    {
        // Check if the new objective is null
        if (newObjective == null)
        {
            // Log an error if a null objective is passed
            Debug.LogError("Attempted to set a null objective!");
            return; // Exit the method to prevent further execution
        }

        // Assign the new objective to the currentObjective variable
        currentObjective = newObjective;

        // Update the UI text if the objectiveText reference is not null
        if (objectiveText != null)
        {
            objectiveText.text = currentObjective.Description; // Display the new objective's description
        }

        // Log the new objective's description for debugging purposes
        Debug.Log("Objective set: " + currentObjective.Description);
    }

    // Marks the current objective as completed
    public void CompleteCurrentObjective()
    {
        // Check if there is a current objective
        if (currentObjective != null)
        {
            // Mark the current objective as completed
            currentObjective.CompleteObjective();

            // Log the completion of the current objective
            Debug.Log("Objective completed: " + currentObjective.Description);
        }
        else
        {
            // Log an error if there is no current objective to complete
            Debug.LogError("No current objective to complete!");
        }
    }
}
