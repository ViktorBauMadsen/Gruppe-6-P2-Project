using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class ObjectiveManager : MonoBehaviour
{

    public TextMeshProUGUI objectiveText; // Reference to the UI Text component
    private Objective currentObjective;

    // Start is called before the first frame update
    void Start()
    {
        // Create a new GameObject for the objective
        GameObject objectiveGO = new GameObject("Objective");
        Objective objective = objectiveGO.AddComponent<Objective>();
        objective.Initialize("Reduce your stress level"); // Add an Initialize method to set the description
        SetObjective(objective);
    }

    // Update is called once per frame
    void Update()
    {
        // Update the UI text with the current objective
        if (currentObjective != null)
        {
            objectiveText.text = currentObjective.Description;
            // Check if the current objective is completed
            if (currentObjective.IsCompleted)
            {
                // Create a new GameObject for the next objective
                GameObject objectiveGO = new GameObject("Objective");
                Objective objective = objectiveGO.AddComponent<Objective>();
                objective.Initialize("Talk to the teacher.");
                SetObjective(objective);
            }
                else if (currentObjective.Description == "Talk to the teacher.")
                {
                    // Add any further objectives or end the objective sequence
                }
        }
    }


    public void SetObjective(Objective newObjective)
    {
        if (newObjective == null)
        {
            Debug.LogError("Attempted to set a null objective!");
            return;
        }

        currentObjective = newObjective;
        if (objectiveText != null)
        {
            objectiveText.text = currentObjective.Description; // Update the UI text
        }
        Debug.Log("Objective set: " + currentObjective.Description);
    }

    public void CompleteCurrentObjective()
    {
        if (currentObjective != null)
        {
            currentObjective.CompleteObjective();
            Debug.Log("Objective completed: " + currentObjective.Description);
        }
        else
        {
            Debug.LogError("No current objective to complete!");
        }
    }
}