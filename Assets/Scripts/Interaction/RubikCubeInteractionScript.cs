using UnityEngine;

public class RubikCubeInteractionScript : MonoBehaviour, IInteractable
{
	public string GetDescription()
	{
		return "Use Rubiks Cube";
	}

	public void Interact()
	{
		StressValueHolder.singleton.RemoveStress(20);
	}
}
