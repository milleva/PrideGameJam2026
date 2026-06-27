using UnityEngine;
using UnityEngine.UI;

public class ImageSwitcher : MonoBehaviour
{
    public Sprite neutralImage;
    public Sprite happyImage;

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
}
