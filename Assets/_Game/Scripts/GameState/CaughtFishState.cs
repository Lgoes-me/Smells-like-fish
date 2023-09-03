public class CaughtFishState : BaseGameplayState
{
    private ScrollManager Scroll { get; }

    public CaughtFishState(ScrollManager scroll)
    {
        Scroll = scroll;
    }
    
    public override void OnStateEnter()
    {
        Scroll.UpdateScrollSpeed(-8);
    }
    
    public override void OnStateExit()
    {
        Scroll.UpdateScrollSpeed(0);
        Scroll.Hide();
    }
}