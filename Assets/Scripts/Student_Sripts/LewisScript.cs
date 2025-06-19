using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class LewisScript : MonoBehaviour, IInteractable
{
	public string GetDescription()
	{
		return "Talk to Lewis";
	}

	public void Interact()
	{
		    SceneManager.LoadScene("LewisConversation_1");
	}	
}
