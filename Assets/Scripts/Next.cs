using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Next : MonoBehaviour
{
    public Button NextButton; // Assign your button in the Inspector
    public string SampleScene; // Name of the scene to load

    void Start()
    {
        if (NextButton != null)
        {
            NextButton.onClick.AddListener(ChangeScene);
        }
    }

    void ChangeScene()
    {
        // Check if the sceneName is set, then load the specified scene
        if (!string.IsNullOrEmpty(SampleScene))
        {
            SceneManager.LoadScene(SampleScene);
        }
        else
        {
            Debug.LogError("Scene name is not set or empty!");
        }
    }
}