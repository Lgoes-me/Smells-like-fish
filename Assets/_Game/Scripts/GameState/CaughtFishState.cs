public class CaughtFishState : BaseGameplayState
{
    private ScrollableAreaController ScrollableArea { get; }

    public CaughtFishState(ScrollableAreaController scrollableArea)
    {
        ScrollableArea = scrollableArea;
    }
    
    public override void OnStateEnter()
    {
        ScrollableArea.StopSpawn();
        ScrollableArea.ScrollSpeed = -8;
        ScrollableArea.UpdateScrollSpeed();
    }
    
    public override void OnStateExit()
    {
        ScrollableArea.ScrollSpeed = 0;
        ScrollableArea.UpdateScrollSpeed();
        ScrollableArea.Hide();
    }
}