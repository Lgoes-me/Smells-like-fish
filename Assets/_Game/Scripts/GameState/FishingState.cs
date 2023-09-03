public class FishingState : BaseGameplayState
{
    private ScrollManager Scroll { get; }

    public FishingState(ScrollManager scroll)
    {
        Scroll = scroll;
    }

    public override void OnStateEnter()
    {
        Scroll.Show();
        Scroll.UpdateScrollSpeed(3);
    }
}