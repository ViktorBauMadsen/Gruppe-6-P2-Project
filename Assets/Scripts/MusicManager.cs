using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    private static MusicManager instance;
    private AudioSource audioSource;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Keep music manager alive across scenes
            audioSource = GetComponent<AudioSource>();
            audioSource.Play(); // Start playing the music
        }
        else
        {
            Destroy(gameObject); // Prevent multiple instances
        }
    }

    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoaded; // Listen for scene changes
    }

    void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        if (scene.name == "Prototype")
        {
            audioSource.Stop(); // Stop music ONLY in "Prototype"
        }
        else if (!audioSource.isPlaying) // If music was stopped, restart it
        {
            audioSource.Play();
        }
    }
}
