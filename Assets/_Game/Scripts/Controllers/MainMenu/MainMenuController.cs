using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [field: SerializeField] private StoreController Store { get; set; }
    [field: SerializeField] private CollectionController Collection { get; set; }
    [field: SerializeField] private ScrollableAreaController ScrollableArea { get; set; }
    
    [field: SerializeField] private Button StoreButton { get; set; }
    [field: SerializeField] private Button CollectionButton { get; set; }
    [field: SerializeField] private Button StartGameButton { get; set; }

    public void Awake()
    {
        StoreButton.onClick.AddListener(() => GameController.Game.ChangeState(new StoreState(Store)));
        CollectionButton.onClick.AddListener(() => GameController.Game.ChangeState(new CollectionState(Collection)));
        StartGameButton.onClick.AddListener(() => GameController.Game.ChangeState(new FishingState(ScrollableArea)));
        
        gameObject.SetActive(false);
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
}