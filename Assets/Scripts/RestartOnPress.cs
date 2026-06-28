using UnityEngine;
using UnityEngine.InputSystem;

public class RestartOnPress : MonoBehaviour
{
    public SceneManager sceneManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        sceneManager = FindFirstObjectByType<SceneManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Keyboard.current.nKey.wasPressedThisFrame)
        {
            GameState.ResetGameState();
            sceneManager.LoadScene("CharacterSelection");
        }

    }
}
