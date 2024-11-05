public class ScoreManager 
{
    private int currentScore;
    
    public ScoreManager()
    {
        currentScore = 0;
    }

    public void AddScore(int amount)
    {
        currentScore += amount;
    }

    public int GetScore()
    {
        return currentScore;
    }
}