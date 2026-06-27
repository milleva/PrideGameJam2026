using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class MultipleChoice : MonoBehaviour
{
    [SerializeField] private GameObject SelectorArrow;
    [SerializeField] private GameObject[] ChoiceOptions;

    public int currentChoiceIndex = 0;

    private int currentOptionCount = 0;

    void Start()
    {
        UpdateSelectorPosition();
    }

    void Update()
    {
        if (Keyboard.current.upArrowKey.wasPressedThisFrame)
        {
            int nextChoiceIndex = currentChoiceIndex - 1;
            if (nextChoiceIndex >= 0)
            {
                currentChoiceIndex = nextChoiceIndex;
            }
            else
            {
                currentChoiceIndex = currentOptionCount - 1;
            }
            UpdateSelectorPosition();
        }
        else if (Keyboard.current.downArrowKey.wasPressedThisFrame)
        {
            int nextChoiceIndex = currentChoiceIndex + 1;
            if (nextChoiceIndex < currentOptionCount)
            {
                currentChoiceIndex = nextChoiceIndex;
            }
            else
            {
                currentChoiceIndex = 0;
            }
            UpdateSelectorPosition();
        }

    }

    private void UpdateSelectorPosition()
    {
        if (SelectorArrow != null && ChoiceOptions.Length > 0)
        {
            Vector3 newPosition = SelectorArrow.transform.position;
            newPosition.y = ChoiceOptions[currentChoiceIndex].transform.position.y;
            SelectorArrow.transform.position = newPosition;
        }
    }


    public void SetCurrentChoices(string[] choices)
    {
        currentOptionCount = choices.Length;
        for (int i = 0; i < ChoiceOptions.Length; i++)
        {
            if (i < choices.Length)
            {
                ChoiceOptions[i].SetActive(true);
                TextMeshProUGUI choiceText = ChoiceOptions[i].GetComponentInChildren<TextMeshProUGUI>();
                if (choiceText != null)
                {
                    choiceText.text = choices[i];
                }
            }
            else
            {
                ChoiceOptions[i].SetActive(false);
            }
        }

        currentChoiceIndex = 0;
        UpdateSelectorPosition();
    }
}
