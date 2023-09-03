public class StartMenuState : BaseGameplayState
{
    private MainMenuController MainMenu { get; }

    public StartMenuState(MainMenuController mainMenu)
    {
        MainMenu = mainMenu;
    }

    public override void OnStateEnter()
    {
        MainMenu.Show();
    }
    
    public override void OnStateExit()
    {
        MainMenu.Hide();
    }
}