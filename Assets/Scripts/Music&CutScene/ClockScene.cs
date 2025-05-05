using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class ClockScene : MonoBehaviour
{
    public string nextSceneName = "Prototype";
    private VideoPlayer videoPlayer;

    void Start()
    {
        videoPlayer = GetComponent<VideoPlayer>();
        videoPlayer.loopPointReached += OnVideoFinished;
    }

    void OnVideoFinished(VideoPlayer vp)
    {
        SceneManager.LoadScene(nextSceneName);
    }
}
