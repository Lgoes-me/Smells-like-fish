public class CollectionState : BaseGameplayState
{
    private CollectionController Collection { get; }

    public CollectionState(CollectionController collection)
    {
        Collection = collection;
    }
    
    public override void OnStateEnter()
    {
        Collection.Show();
    }
    
    public override void OnStateExit()
    {
        Collection.Hide();
    }
}