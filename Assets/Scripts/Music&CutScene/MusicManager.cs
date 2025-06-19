using UnityEngine;
using UnityEngine.SceneManagement;


// This script manages background music across scenes in Unity.
// It ensures that the music keeps playing across most scenes — except for a specific one — without restarting.
// It also prevents multiple copies of the music manager from being created.

public class MusicManager : MonoBehaviour
{
    // Static reference to the one and only instance of the MusicManager.
    // This makes it possible to enforce a singleton pattern — a design pattern that ensures only one instance exists.
    private static MusicManager instance;

    // A reference to the AudioSource component attached to this GameObject.
    // This is what actually plays the music.
    private AudioSource audioSource;

    // We store the name of the last scene we saw, so we can detect when a scene change happens.
    private string lastSceneName = "";

    // The Awake function is called when the script instance is being loaded.
    // It's used here to set up the singleton and preserve the music manager across scene loads.
    void Awake()
    {
        // If no MusicManager exists yet...
        if (instance == null)
        {
            // Set this object as the instance.
            instance = this;

            // Don't destroy this object when a new scene is loaded.
            // This allows the music to continue playing without restarting.
            DontDestroyOnLoad(gameObject);

            // Get the AudioSource component attached to this GameObject.
            // This assumes the AudioSource is already attached in the Inspector.
            audioSource = GetComponent<AudioSource>();
        }
        else
        {
            // If a MusicManager already exists, destroy this new one to avoid duplicates.
            Destroy(gameObject);
        }
    }

    // The Update function runs once per frame.
    // Here, we check whether the scene has changed since the last frame.
    void Update()
    {
        // Get the name of the current active scene.
        string currentScene = SceneManager.GetActiveScene().name;

        // Only proceed if the scene has changed since the last frame.
        if (currentScene != lastSceneName)
        {
            // Update the lastSceneName to the current scene, so we can detect the next change.
            lastSceneName = currentScene;

            // If we've entered the scene named "Prototype"...
            if (currentScene == "Prototype")
            {
                // And if the music is currently playing...
                if (audioSource.isPlaying)
                    // Stop the music because we don't want it to play in the Prototype scene.
                    audioSource.Stop();
            }
            else
            {
                // In any other scene, if the music is not playing...
                if (!audioSource.isPlaying)
                    // Start playing the music.
                    audioSource.Play();
            }
        }
    }
}