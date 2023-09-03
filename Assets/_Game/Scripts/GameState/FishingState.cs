public class FishingState : BaseGameplayState
{
    private ScrollableAreaController ScrollableArea { get; }

    public FishingState(ScrollableAreaController scrollableArea)
    {
        ScrollableArea = scrollableArea;
    }

    public override void OnStateEnter()
    {
        ScrollableArea.Show();
        ScrollableArea.ScrollSpeed = 3;
        ScrollableArea.UpdateScrollSpeed();
        ScrollableArea.SpawnEnemies();
    }
}