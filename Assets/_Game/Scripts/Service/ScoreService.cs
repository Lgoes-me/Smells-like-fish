public class ScoreService
{
    public int CurrentGameScore { get; private set; }
    public int TotalScore { get; private set; }

    public void ResetCurrentScore()
    {
        CurrentGameScore = 0;
    }
    
    public void AddCurrentScore(int score)
    {
        CurrentGameScore += score;
        TotalScore += score;
    }
}