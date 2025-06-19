using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

// This script is responsible for controlling a video cutscene,
// and automatically loading a new scene when the video finishes playing.

public class ClockScene : MonoBehaviour
{
    // This public string allows you to set the name of the next scene in the Inspector.
    // In this case, the default value is "Prototype".
    public string nextSceneName = "Prototype";

    // A private reference to the VideoPlayer component that plays the cutscene video.
    private VideoPlayer videoPlayer;

    // The Start method is called once when the script is first run.
    void Start()
    {
        // Get the VideoPlayer component attached to the same GameObject.
        // This is necessary so we can interact with the video being played.
        videoPlayer = GetComponent<VideoPlayer>();

        // We subscribe to the `loopPointReached` event.
        // This event is triggered when the video reaches the end of playback.
        // We assign our own method `OnVideoFinished` to handle that event.
        videoPlayer.loopPointReached += OnVideoFinished;
    }

    // This method is called automatically when the video finishes playing.
    // It receives a reference to the VideoPlayer that just finished.
    void OnVideoFinished(VideoPlayer vp)
    {
        // When the video ends, we load the next scene.
        // The name of the scene is defined by the `nextSceneName` variable.
        SceneManager.LoadScene(nextSceneName);
    }
}
