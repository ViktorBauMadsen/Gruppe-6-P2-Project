using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class Objectivemanager : MonoBehaviour
{

    public TextMeshProUGUI objectiveText; // Reference to the UI Text component
    private Objective currentObjective;

    // Start is called before the first frame update
    void Start()
    {
        // Example of setting an initial objective
        SetObjective(new Objective("Find the key to unlock the door."));
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
                // Set a new objective when the current one is completed
                SetObjective(new Objective("Unlock the door with the key."));
            }
        }
    }

    public void SetObjective(Objective newObjective)
    {
        currentObjective = newObjective;
    }

    public void CompleteCurrentObjective()
    {
        if (currentObjective != null)
        {
            currentObjective.CompleteObjective();
        }
    }
}