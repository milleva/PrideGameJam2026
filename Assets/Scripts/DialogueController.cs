using UnityEngine;
using UnityEngine.InputSystem;

[System.Serializable]
public class DialogueChoiceGroup
{
    public string[] options = new string[0];
}

public class DialogueController : MonoBehaviour
{
    [SerializeField] private TextMeshHandler dialogueHandler;

    private int currentLineIndex = 0;

    public string[] dialogueLines = new string[]
    {
        "Are you old?",
        "Welcome to our game.",
        "We hope you enjoy your experience."
    };

    public DialogueChoiceGroup[] choices = new DialogueChoiceGroup[]
    {
        new DialogueChoiceGroup { options = new string[] { "Yes", "No" } },
        new DialogueChoiceGroup { options = new string[] { "Option 1", "Option 2", "Option 3" } },
        new DialogueChoiceGroup { options = new string[] { "Option A", "Option B", "Option C" } }
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
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            NextDialogueLine();
        }
    }

    void NextDialogueLine()
    {
        int nextLineIndex = currentLineIndex + 1;
        if (nextLineIndex < dialogueLines.Length)
        {
            dialogueHandler.DisplayDialogue(dialogueLines[nextLineIndex]);
            currentLineIndex = nextLineIndex;
        }

    }
}

