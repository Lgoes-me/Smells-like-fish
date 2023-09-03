using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    [field: SerializeField] private Button ContinueButton { get; set; }

    public ScoreController Init()
    {
        ContinueButton.onClick.AddListener(() => GameController.Game.ChangeState<EndGameState>());
        gameObject.SetActive(false);
        return this;
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        SceneManager.LoadScene(0);
    }  
}