using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class ShannonScript : MonoBehaviour, IInteractable
{
	public string GetDescription()
	{
		return "Talk to Shannon";
	}

	public void Interact()
	{
		     SceneManager.LoadScene("ShannonConversation_1");
	}
}
