using UnityEngine;
using UnityEngine.InputSystem;

public class DialogueController : MonoBehaviour
{
    [SerializeField] private TextMeshHandler currentSpeakerNameHandler;
    [SerializeField] private TextMeshHandler dialogueHandler;

    private int currentLineIndex = 0;

    public string[] dialogueLines = new string[]
    {
        "Hello there!",
        "Welcome to our game.",
        "We hope you enjoy your experience."
    };

    void Start()
    {
        if (dialogueLines.Length > 0)
        {
            dialogueHandler.DisplayDialogue(dialogueLines[0]);
        }
    }

    void Update()
    {
        // on spacebar press, display the next line of dialogue
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            int nextLineIndex = currentLineIndex + 1;
            if (nextLineIndex < dialogueLines.Length)
            {
                dialogueHandler.DisplayDialogue(dialogueLines[nextLineIndex]);
                currentLineIndex = nextLineIndex;
            }
        }

    }
}
