using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class MeganScript : MonoBehaviour, IInteractable
{
	public string GetDescription()
	{
		return "Talk to Megan";
	}

	public void Interact()
	{
		    SceneManager.LoadScene("MeganConversation_1");
	}
}
