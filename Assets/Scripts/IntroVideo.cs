using UnityEngine;
using UnityEngine.InputSystem;
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

    void Update()
{
    if (Keyboard.current.spaceKey.wasPressedThisFrame)
    {
        sceneManager.LoadScene("CharacterSelection");
    }
}

    void OnVideoFinished(VideoPlayer vp)
    {
        sceneManager.LoadScene("CharacterSelection");
    }
}
