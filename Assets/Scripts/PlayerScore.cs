using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public SceneManager sceneManager;

    public int wealthPoints = 0;
    public int susPoints = 0;
    public int pedoPoints = 0;

    public int maximumPedoPointThreshold = 100; // Example threshold
    public int maximumSusPointThreshold = 100; // Example threshold
    public int minimumWealthPointThreshold = -10; // Example threshold

    public void AddPoints(int wealth, int sus, int pedo)
    {
        wealthPoints += wealth;
        susPoints += sus;
        pedoPoints += pedo;

        GameState.wealthPoints = wealthPoints;
        GameState.susPoints = susPoints;
        GameState.pedoPoints = pedoPoints;

        if (pedoPoints >= maximumPedoPointThreshold)
        {
            Debug.Log("You lost due to pedophilia!");
            sceneManager.LoadScene("GameOver");
        }

        if (susPoints >= maximumSusPointThreshold)
        {
            Debug.Log("You lost for being too sus!");
            sceneManager.LoadScene("GameOver");
        }

        if (wealthPoints <= minimumWealthPointThreshold)
        {
            Debug.Log("You lost due to being too broke!");
            sceneManager.LoadScene("GameOver");
        }

        Debug.Log(
            $"Player Score Updated: Wealth Points = {wealthPoints}, Sus Points = {susPoints}, Pedo Points = {pedoPoints}"
            );
    }


    void Start()
    {

    }

    void Update()
    {

    }
}
