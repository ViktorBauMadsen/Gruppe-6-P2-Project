using UnityEngine;

public class Objective : MonoBehaviour
{
    public string Description { get; private set; }
    public bool IsCompleted { get; private set; }

    public Objective(string description)
    {
        Description = description;
        IsCompleted = false;
    }
    public void CompleteObjective()
    {
        IsCompleted = true;
    }
}
