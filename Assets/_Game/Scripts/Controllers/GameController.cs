using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController Game { get; private set; }
    
    [field: SerializeField] private MainMenuController MainMenu { get; set; }
    [field: SerializeField] private StoreController Store { get; set; }
    [field: SerializeField] private CollectionController Collection { get; set; }
    [field: SerializeField] private ScrollManager Scroll { get; set; }
    [field: SerializeField] private ScoreController Score { get; set; }
    
    private BaseGameplayState State { get; set; }
    private Dictionary<Type,BaseGameplayState> States { get; set; }
    
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
        Scroll.Init();
        
        States = new List<BaseGameplayState>()
        {
            new MainMenuState(MainMenu.Init()),
            new StoreState(Store.Init()),
            new CollectionState(Collection.Init()),
            new FishingState(Scroll),
            new CaughtFishState(Scroll),
            new ScoreState(Score.Init()),
            new EndGameState(),
        }.ToDictionary(s => s.GetType(), s=> s);

        State = States[typeof(MainMenuState)];
        State.OnStateEnter();
    }

    public void ChangeState<T>() where T : BaseGameplayState
    {
        var nextState = States[typeof(T)];
        
        State.OnStateExit();
        State = nextState;
        State.OnStateEnter();
    }
}