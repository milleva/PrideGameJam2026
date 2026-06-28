using TMPro;
using UnityEngine;

public class PulsatingText : MonoBehaviour
{
    private TextMeshProUGUI textMesh;
    [SerializeField] private float minAlpha = 0.35f;
    [SerializeField] private float maxAlpha = 1f;
    [SerializeField] private float pulseSpeed = 1.5f;

    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if (textMesh == null)
        {
            return;
        }

        float t = Mathf.PingPong(Time.time * pulseSpeed, 1f);
        float alpha = Mathf.Lerp(minAlpha, maxAlpha, t);
        Color color = textMesh.color;
        color.a = alpha;
        textMesh.color = color;
    }
}
