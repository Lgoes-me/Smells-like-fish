using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
    [field: SerializeField] private Button StoreButton { get; set; }
    [field: SerializeField] private Button CollectionButton { get; set; }
    [field: SerializeField] private Button StartGameButton { get; set; }

    public MainMenuController Init()
    {
        StoreButton.onClick.AddListener(() => GameController.Game.ChangeState<StoreState>());
        CollectionButton.onClick.AddListener(() => GameController.Game.ChangeState<CollectionState>());
        StartGameButton.onClick.AddListener(() => GameController.Game.ChangeState<FishingState>());
        
        gameObject.SetActive(false);
        return this;
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