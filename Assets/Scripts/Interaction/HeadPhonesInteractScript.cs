using UnityEngine;

public class HeadPhonesInteractScript : MonoBehaviour, IInteractable
{
	public string GetDescription()
	{
		return "Use Headphones";
	}

	public void Interact()
	{
		StressValueHolder.singleton.RemoveStress(20);
	}
}
