using TMPro;
using UnityEngine;

public class PointsTextFromGameState : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textMesh;

    void Start()
    {
        string explanation = "";

        if (GameState.wealthPoints <= PlayerScore.minimumWealthPointThreshold)
        {
            explanation = "You lost due to being too broke!";
        }
        else if (GameState.susPoints >= PlayerScore.maximumSusPointThreshold)
        {
            explanation = "You lost for being too sus!";
        }
        else if (GameState.pedoPoints >= PlayerScore.maximumPedoPointThreshold)
        {
            explanation = "You lost due to pedophilia!";
        }

        textMesh = GetComponent<TextMeshProUGUI>();
        textMesh.text = $"{explanation}\n\nWealth Points: {GameState.wealthPoints}\nSus Points: {GameState.susPoints}\nPedo Points: {GameState.pedoPoints}";
    }

    void Update()
    {

    }
}
