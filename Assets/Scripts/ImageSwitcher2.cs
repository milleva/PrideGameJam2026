using UnityEngine;
using UnityEngine.UI;

public class ImageSwitcher2 : MonoBehaviour
{
    public Sprite scroogePartnerImage;
    public Sprite burnsPartnerImage;
    public Sprite crabPartnerImage;

    [SerializeField] private Image sourceImage;

    void Awake()
    {
        if (sourceImage == null)
        {
            sourceImage = GetComponentInChildren<Image>(true);
        }
    }

    public void SwitchToBurnsPartnerImage()
    {
        if (sourceImage != null && burnsPartnerImage != null)
        {
            sourceImage.sprite = burnsPartnerImage;
        }
    }

    public void SwitchToScroogePartnerImage()
    {
        if (sourceImage != null && scroogePartnerImage != null)
        {
            sourceImage.sprite = scroogePartnerImage;
        }
    }

    public void SwitchToCrabPartnerImage()
    {
        if (sourceImage != null && crabPartnerImage != null)
        {
            sourceImage.sprite = crabPartnerImage;
        }
    }
}
