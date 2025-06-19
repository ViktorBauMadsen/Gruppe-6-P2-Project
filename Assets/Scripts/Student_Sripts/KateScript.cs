using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class KateScript : MonoBehaviour, IInteractable
{
	public string GetDescription()
	{
		return "Talk to Kate";
	}

	public void Interact()
	{
		   SceneManager.LoadScene("KateConversation_1");
	}
}