using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Game { get; private set; }
    
    [field: SerializeField] private MainMenuController MainMenu { get; set; }
    
    private BaseGameplayState State { get; set; }
    
    private void Awake() 
    { 
        if (Game != null && Game != this) 
        { 
            Destroy(this); 
        } 
        else 
        { 
            Game = this; 
        } 
    }
    
    private void Start()
    {
        State = new StartMenuState(MainMenu);
        State.OnStateEnter();
    }

    public void ChangeState(BaseGameplayState nextState)
    {
        State.OnStateExit();
        State = nextState;
        State.OnStateEnter();
    }
}