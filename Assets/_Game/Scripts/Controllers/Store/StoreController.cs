using UnityEngine;
using UnityEngine.UI;

public class StoreController : MonoBehaviour
{
    [field: SerializeField] private Button CloseButton { get; set; }
    
    public StoreController Init()
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