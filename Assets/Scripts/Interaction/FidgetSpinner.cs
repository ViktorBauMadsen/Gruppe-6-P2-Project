using Unity.VisualScripting;
using UnityEngine;

public class FidgetSpinner : MonoBehaviour, IInteractable
{
    private Animator animator;
    private ObjectiveManager objectiveManager;

    private void Start()
    {
        animator = GetComponent<Animator>();
        objectiveManager = FindObjectOfType<ObjectiveManager>();

    }

    public string GetDescription()
    {
        return "To spin";
    }

    public void Interact()
    {
        animator.SetTrigger("Spin");
        Debug.Log("Fidget spinner interacted with.");
        objectiveManager.CompleteCurrentObjective();

        StressValueHolder.singleton.RemoveStress(15);

    }
}