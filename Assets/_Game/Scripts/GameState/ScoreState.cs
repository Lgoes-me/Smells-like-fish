﻿public class ScoreState : BaseGameplayState
{
    private ScoreController Score { get; }
    
    public ScoreState(ScoreController score)
    {
        Score = score;
    }

    public override void OnStateEnter()
    {
        Score.Show();
    }
    
    public override void OnStateExit()
    {
        GameController.Game.Application.ScoreService.ResetCurrentScore();
        Score.Hide();
    }
}