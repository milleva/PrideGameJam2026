using TMPro;
using UnityEngine;

public class TextMeshHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dialogueText;

    public void DisplayDialogue(string dialogue)
    {
        dialogueText.text = dialogue;
    }
}
