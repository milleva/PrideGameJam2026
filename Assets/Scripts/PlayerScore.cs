using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    public int wealthPoints = 0;
    public int susPoints = 0;
    public int pedoPoints = 0;

    public void AddPoints(int wealth, int sus, int pedo)
    {
        wealthPoints += wealth;
        susPoints += sus;
        pedoPoints += pedo;

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
