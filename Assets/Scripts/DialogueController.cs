    using UnityEngine;
    using UnityEngine.InputSystem;

    public class DialogueController : MonoBehaviour
{
        [SerializeField] private PlayerScore playerScore;
        [SerializeField] private TextMeshHandler dialogueTextHandler;
    [SerializeField] private MultipleChoice multipleChoiceHandler;

        // hide multiple choice box whenever displaying response text, show it again when displaying next dialogue line
        public GameObject multipleChoiceBox;

        private int currentLineIndex = 0;

        public string[] dialogueLines = new string[]
        {
            "Are you old?",
            "Welcome to our game.",
            "We hope you enjoy your experience."
        };

        public DialogueChoiceGroup[] choices = new DialogueChoiceGroup[]
        {
            new DialogueChoiceGroup { options = new DialogueChoice[] { new DialogueChoice { text = "Old enough" }, new DialogueChoice { text = "Young" } } },
            new DialogueChoiceGroup { options = new DialogueChoice[] { new DialogueChoice { text = "Option 1" }, new DialogueChoice { text = "Option 2" }, new DialogueChoice { text = "Option 3" } } },
            new DialogueChoiceGroup { options = new DialogueChoice[] { new DialogueChoice { text = "Option A" }, new DialogueChoice { text = "Option B" }, new DialogueChoice { text = "Option C" } } }
        };
        private string currentResponseText = null;
        private bool isRespondingNext = false;

        void Start()
        {
            if (dialogueLines.Length > 0)
            {
                dialogueTextHandler.DisplayDialogue(dialogueLines[0]);
            }
            if (choices.Length > 0)
            {
                DialogueChoice[] currentChoices = choices[0].options;
            multipleChoiceHandler.SetCurrentChoices(
                System.Array.ConvertAll(currentChoices, choice => choice.text)
            );
                isRespondingNext = true;
            }
        }

    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            if (!isRespondingNext)
            {
                NextDialogueLine();
            }
            else
            {
                DialogueChoice[] previousChoices = choices[currentLineIndex].options;
                DialogueChoice selectedChoice = previousChoices[multipleChoiceHandler.currentChoiceIndex];
                currentResponseText = selectedChoice.responseText;
                playerScore.AddPoints(selectedChoice.wealthPoints, selectedChoice.susPoints, selectedChoice.pedoPoints);
                NextResponse();
            }
        }
    }

        void NextResponse()
        {
            if (currentResponseText != null)
            {
                if (multipleChoiceBox != null)
                {
                    multipleChoiceBox.SetActive(false);
                }
                dialogueTextHandler.DisplayDialogue(currentResponseText);
                currentResponseText = null;
                isRespondingNext = false;
            }
        }

        void NextDialogueLine()
        {
                int nextLineIndex = currentLineIndex + 1;
                if (nextLineIndex < dialogueLines.Length)
                {
                    if (multipleChoiceBox != null)
                    {
                        multipleChoiceBox.SetActive(true);
                    }
                    string nextLine = dialogueLines[nextLineIndex];
                    dialogueTextHandler.DisplayDialogue(nextLine);
                    currentLineIndex = nextLineIndex;
                }
                if (nextLineIndex < choices.Length)
                {
                    DialogueChoice[] currentChoices = choices[nextLineIndex].options;
                    multipleChoiceHandler.SetCurrentChoices(
                        System.Array.ConvertAll(currentChoices, choice => choice.text)
                    );
                }
                isRespondingNext = true;
        }
    }

