using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class OpeningVideo : MonoBehaviour
{
    public SceneManager SceneManager;
    [SerializeField] private VideoPlayer videoPlayer;
    [SerializeField] private string videoFileName = "opening_2.mp4";
    [SerializeField] private string nextSceneName = "CharacterSelection";

    private IEnumerator Start()
    {
        videoPlayer.source = VideoSource.Url;
        videoPlayer.url = System.IO.Path.Combine(
            Application.streamingAssetsPath,
            videoFileName
        );

        videoPlayer.Prepare();

        while (!videoPlayer.isPrepared)
            yield return null;

        videoPlayer.Play();
        videoPlayer.loopPointReached += _ =>
        {
            SceneManager.LoadScene(nextSceneName);
        };
    }

    private void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
            SceneManager.LoadScene(nextSceneName);
    }
}