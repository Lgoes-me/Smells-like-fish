using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreController : MonoBehaviour
{
    [field: SerializeField] private Button ContinueButton { get; set; }

    private void Awake()
    {
        ContinueButton.onClick.AddListener(() => GameController.Game.ChangeState(new EndGameState()));
        gameObject.SetActive(false);
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