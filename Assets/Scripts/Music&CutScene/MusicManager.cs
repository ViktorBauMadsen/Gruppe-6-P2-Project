using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    private static MusicManager instance;
    private AudioSource audioSource;
    private string lastSceneName = "";

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
            audioSource = GetComponent<AudioSource>();
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        string currentScene = SceneManager.GetActiveScene().name;

        // Only react when the scene changes
        if (currentScene != lastSceneName)
        {
            lastSceneName = currentScene;

            if (currentScene == "Prototype")
            {
                if (audioSource.isPlaying)
                    audioSource.Stop();
            }
            else
            {
                if (!audioSource.isPlaying)
                    audioSource.Play();
            }
        }
    }
}