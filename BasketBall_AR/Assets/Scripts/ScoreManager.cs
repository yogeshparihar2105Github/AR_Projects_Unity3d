using UnityEngine;

public static class ScoreManager
{
    private static int score = 0;

    public static void IncreaseScore(int amount)
    {
        score += amount;
    }
    public static int GetScore()
    {
        return score;
    }


}
