using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class CharacterSelection : MonoBehaviour
{
    public GameObject[] choosableCharacters;
    public GameObject selectorArrow;
    public FadeableObject fadeInForeGround;

    [SerializeField] private float selectedScaleMultiplier = 1.08f;
    [SerializeField] private float selectedPopOutDistance = 0.2f;
    [SerializeField] private float nonSelectedOpacity = 0.1f;

    private int currentCharacterIndex = 0;
    private Vector3[] baseLocalPositions;
    private Vector3[] baseLocalScales;

    void CacheCharacterDefaults()
    {
        if (choosableCharacters == null)
        {
            baseLocalPositions = new Vector3[0];
            baseLocalScales = new Vector3[0];
            return;
        }

        if (baseLocalPositions != null && baseLocalPositions.Length == choosableCharacters.Length)
        {
            return;
        }

        baseLocalPositions = new Vector3[choosableCharacters.Length];
        baseLocalScales = new Vector3[choosableCharacters.Length];

        for (int i = 0; i < choosableCharacters.Length; i++)
        {
            if (choosableCharacters[i] == null)
            {
                continue;
            }

            baseLocalPositions[i] = choosableCharacters[i].transform.localPosition;
            baseLocalScales[i] = choosableCharacters[i].transform.localScale;
        }
    }

    void SetCharacterOpacity(GameObject character, float alpha)
    {
        if (character == null)
        {
            return;
        }

        Image[] images = character.GetComponentsInChildren<Image>(true);
        for (int i = 0; i < images.Length; i++)
        {
            Color color = images[i].color;
            color.a = alpha;
            images[i].color = color;
        }
    }

    void SetArrowXPositionToCurrentCharacter()
    {
        if (selectorArrow != null && choosableCharacters.Length > 0 && choosableCharacters[currentCharacterIndex] != null)
        {
            Vector3 newPosition = selectorArrow.transform.position;
            newPosition.x = choosableCharacters[currentCharacterIndex].transform.position.x;
            selectorArrow.transform.position = newPosition;
        }
    }

    void SetCurrentSelection()
    {
        CacheCharacterDefaults();
        SetArrowXPositionToCurrentCharacter();

        for (int i = 0; i < choosableCharacters.Length; i++)
        {
            GameObject character = choosableCharacters[i];
            if (character == null)
            {
                continue;
            }

            bool isSelected = i == currentCharacterIndex;
            character.transform.localScale = isSelected
                ? baseLocalScales[i] * selectedScaleMultiplier
                : baseLocalScales[i];

            Vector3 position = baseLocalPositions[i];
            if (isSelected)
            {
                position.y += selectedPopOutDistance;
            }

            character.transform.localPosition = position;
            SetCharacterOpacity(character, isSelected ? 1f : nonSelectedOpacity);

            ImageSwitcher imageSwitcher = character.GetComponent<ImageSwitcher>();
            if (imageSwitcher != null) {
                Debug.Log($"Setting image for character {character.name} to {(isSelected ? "happy" : "neutral")}");
                if (isSelected)
                {
                    imageSwitcher.SwitchToHappyImage();
                }
                else
                {
                    imageSwitcher.SwitchToNeutralImage();
                }
            }
        }
    }

    void Start()
    {
        SetCurrentSelection();
    }

    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            if (fadeInForeGround != null)
            {
                fadeInForeGround.StartFade();
            }
        }

        if (Keyboard.current.leftArrowKey.wasPressedThisFrame)
        {
            int nextCharacterIndex = currentCharacterIndex - 1;
            if (nextCharacterIndex >= 0)
            {
                currentCharacterIndex = nextCharacterIndex;
            }
            else
            {
                currentCharacterIndex = choosableCharacters.Length - 1;
            }
            SetCurrentSelection();
        }
        else if (Keyboard.current.rightArrowKey.wasPressedThisFrame)
        {
            int nextCharacterIndex = currentCharacterIndex + 1;
            if (nextCharacterIndex < choosableCharacters.Length)
            {
                currentCharacterIndex = nextCharacterIndex;
            }
            else
            {
                currentCharacterIndex = 0;
            }
            SetCurrentSelection();
        }
    }
}
