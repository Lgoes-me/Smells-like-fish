public class ScoreState : BaseGameplayState
{
    private ScoreController Score { get; }
    private PlayerController Player { get; }
    
    public ScoreState(ScoreController score, PlayerController player)
    {
        Score = score;
        Player = player;
    }

    public override void OnStateEnter()
    {
        Player.transform.parent = null;
        Score.Show();
    }
    
    public override void OnStateExit()
    {
        Score.Hide();
    }
}