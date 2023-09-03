public class StoreState : BaseGameplayState
{
    private StoreController Store { get; }

    public StoreState(StoreController store)
    {
        Store = store;
    }
    
    public override void OnStateEnter()
    {
        Store.Show();
    }
    
    public override void OnStateExit()
    {
        Store.Hide();
    }
}