using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class NextSceneTeaacher : MonoBehaviour, IInteractable
{
    

   

    public string GetDescription()
    {
        return "Talk to Teacher";
    }

    public void Interact()
    {
       SceneManager.LoadScene("QuizScene4");
    }
}
