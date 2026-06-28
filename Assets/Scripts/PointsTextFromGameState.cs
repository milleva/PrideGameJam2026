using TMPro;
using UnityEngine;

public class PointsTextFromGameState : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMesh;

    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();
        textMesh.text = $"Wealth Points: {GameState.wealthPoints}\nSus Points: {GameState.susPoints}\nPedo Points: {GameState.pedoPoints}";
    }

    void Update()
    {

    }
}
