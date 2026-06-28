public static class GameState
{
    public static int wealthPoints = 0;
    public static int susPoints = 0;
    public static int pedoPoints = 0;

    public static string targetName = ""; //burns, crab, scrooge

    public static void ResetGameState()
    {
        wealthPoints = 0;
        susPoints = 0;
        pedoPoints = 0;

        targetName = "";
    }
}