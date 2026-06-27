using UnityEngine;
using UnityEngine.UI;

public class ImageSwitcher : MonoBehaviour
{
    public Sprite neutralImage;
    public Sprite happyImage;
    public Sprite angryImage;

    [SerializeField] private Image sourceImage;

    void Awake()
    {
        if (sourceImage == null)
        {
            sourceImage = GetComponentInChildren<Image>(true);
        }
    }

    public void SwitchToHappyImage()
    {
        if (sourceImage != null && happyImage != null)
        {
            sourceImage.sprite = happyImage;
        }
    }

    public void SwitchToNeutralImage()
    {
        if (sourceImage != null && neutralImage != null)
        {
            sourceImage.sprite = neutralImage;
        }
    }

    public void SwitchToAngryImage()
    {
        if (sourceImage != null && angryImage != null)
        {
            sourceImage.sprite = angryImage;
        }
    }

    public void SwitchToImageForState(DialogueResultingState state)
    {
        switch (state)
        {
            case DialogueResultingState.neutral:
                SwitchToNeutralImage();
                break;
            case DialogueResultingState.happy:
                SwitchToHappyImage();
                break;
            case DialogueResultingState.angry:
                SwitchToAngryImage();
                break;
            default:
                Debug.LogWarning($"Unhandled DialogueResultingState: {state}");
                break;
        }
    }
}
