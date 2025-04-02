using UnityEngine;

public class Objective : MonoBehaviour
{
    public string Description { get; private set; }

    public Objective(string description)
    {
        Description = description;
    }
}
