using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class RemyScript : MonoBehaviour, IInteractable
{
	public string GetDescription()
	{
		return "Talk to Remy";
	}

	public void Interact()
	{
		 SceneManager.LoadScene("RemyConversation_1");
	}
}
