using Unity.VisualScripting; // Allows use of Visual Scripting features in Unity
using UnityEngine; // Provides access to Unity engine core classes

// FidgetSpinner class represents a fidget spinner object that can be interacted with in the game
public class FidgetSpinner : MonoBehaviour, IInteractable // Inherits from MonoBehaviour and implements IInteractable interface
{
    private Animator animator; // Reference to the Animator component for controlling animations
    private ObjectiveManager objectiveManager; // Reference to the ObjectiveManager to update objectives

    private void Start() // Unity's Start method, called before the first frame update
    {
        animator = GetComponent<Animator>(); // Get the Animator component attached to this GameObject
        objectiveManager = FindObjectOfType<ObjectiveManager>(); // Find the ObjectiveManager in the scene
    }

    public string GetDescription() // Returns a description of the interaction for UI or prompts
    {
        return "To spin"; // Description shown to the player
    }

    public void Interact() // Method called when the player interacts with the fidget spinner
    {
        animator.SetTrigger("Spin"); // Trigger the "Spin" animation on the Animator
        Debug.Log("Fidget spinner interacted with."); // Log the interaction for debugging
        objectiveManager.CompleteCurrentObjective(); // Mark the current objective as completed

        StressValueHolder.singleton.RemoveStress(15); // Reduce the player's stress by 15 using the singleton instance
    }
}