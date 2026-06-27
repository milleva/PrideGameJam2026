using UnityEngine;
using UnityEngine.UI;

public class FadeableObject : MonoBehaviour
{
    public int startingAlpha = 255; // Starting alpha value (0-255)
    public int endAlpha = 0; // Target alpha value (0-255)

    public float fadeDuration = 2.0f; // Duration of the fade in seconds

    private float elapsedTime = 0f;
    private Image image;

    private bool isFading = false;

    public void StartFade()
    {
        // Set the initial alpha value
        Color color = image.color;
        color.a = startingAlpha / 255f;
        image.color = color;
        isFading = true;
        elapsedTime = 0f; // Reset elapsed time when starting the fade
    }

    void Start()
    {
        image = GetComponent<Image>();
        elapsedTime = 0f;

        // Set the initial alpha value
        Color color = image.color;
        color.a = startingAlpha / 255f;
        image.color = color;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isFading)
        {
            return;
        }

        elapsedTime += Time.deltaTime;

        if (elapsedTime <= fadeDuration)
        {
            float t = elapsedTime / fadeDuration;
            int currentAlpha = (int)Mathf.Lerp(startingAlpha, endAlpha, t);

            Color color = image.color;
            color.a = currentAlpha / 255f;
            image.color = color;
        }
        else
        {
            isFading = false;
        }
    }


}
