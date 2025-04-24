using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class JodyScript : MonoBehaviour, IInteractable
{
    public string GetDescription()
    {
        return "Talk to Jody";
    }

    public void Interact()
    {
       SceneManager.LoadScene("JodyConversation_1");
    }
}
