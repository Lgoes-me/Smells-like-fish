using UnityEngine;
using UnityEngine.UI;

public class CollectionController: MonoBehaviour
{
    [field: SerializeField] private Button CloseButton { get; set; }
    
    public CollectionController Init()
    {
        CloseButton.onClick.AddListener(() => GameController.Game.ChangeState<MainMenuState>());
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