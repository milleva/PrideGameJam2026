using UnityEngine;
using UnityEngine.InputSystem;

public class MultipleChoice : MonoBehaviour
{
    [SerializeField] private GameObject SelectorArrow;
    [SerializeField] private GameObject[] ChoiceOptions;

    private int currentChoiceIndex = 0;

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
                currentChoiceIndex = ChoiceOptions.Length - 1;
            }
            UpdateSelectorPosition();
        }
        else if (Keyboard.current.downArrowKey.wasPressedThisFrame)
        {
            int nextChoiceIndex = currentChoiceIndex + 1;
            if (nextChoiceIndex < ChoiceOptions.Length)
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
}
