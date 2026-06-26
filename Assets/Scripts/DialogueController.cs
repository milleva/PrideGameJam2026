using UnityEngine;
using UnityEngine.InputSystem;

public class DialogueController : MonoBehaviour
{
    [SerializeField] private TextMeshHandler dialogueTextHandler;
    [SerializeField] private MultipleChoice multipleChoiceHandler;

    private int currentLineIndex = 0;

    public string[] dialogueLines = new string[]
    {
        "Are you old?",
        "Welcome to our game.",
        "We hope you enjoy your experience."
    };

    public DialogueChoiceGroup[] choices = new DialogueChoiceGroup[]
    {
        new DialogueChoiceGroup { options = new string[] { "Old enough", "Young" } },
        new DialogueChoiceGroup { options = new string[] { "Option 1", "Option 2", "Option 3" } },
        new DialogueChoiceGroup { options = new string[] { "Option A", "Option B", "Option C" } }
    };

    void Start()
    {
        if (dialogueLines.Length > 0)
        {
            dialogueTextHandler.DisplayDialogue(dialogueLines[0]);
        }
        if (choices.Length > 0)
        {
            string[] currentChoices = choices[0].options;
            multipleChoiceHandler.SetCurrentChoices(currentChoices);
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
            string nextLine = dialogueLines[nextLineIndex];
            dialogueTextHandler.DisplayDialogue(nextLine);
            currentLineIndex = nextLineIndex;
        }
        if (nextLineIndex < choices.Length)
        {
            string[] currentChoices = choices[nextLineIndex].options;
            multipleChoiceHandler.SetCurrentChoices(currentChoices);
        }

    }
}

