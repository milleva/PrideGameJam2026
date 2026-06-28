using UnityEngine;
using UnityEngine.Video;


public class IntroVideo : MonoBehaviour
{
    public SceneManager sceneManager;
    public VideoPlayer videoPlayer;

    void Start()
    {
        sceneManager = FindFirstObjectByType<SceneManager>();
        videoPlayer.loopPointReached += OnVideoFinished;
    }

    void OnVideoFinished(VideoPlayer vp)
    {
        sceneManager.LoadScene("CharacterSelection");
    }
}
