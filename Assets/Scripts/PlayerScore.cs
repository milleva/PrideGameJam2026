using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public int wealthPoints = 0;
    public int susPoints = 0;

    public void AddPoints(int wealth, int sus)
    {
        wealthPoints += wealth;
        susPoints += sus;

        Debug.Log(
            $"Player Score Updated: Wealth Points = {wealthPoints}, Sus Points = {susPoints}"
            );
    }


    void Start()
    {

    }

    void Update()
    {

    }
}
