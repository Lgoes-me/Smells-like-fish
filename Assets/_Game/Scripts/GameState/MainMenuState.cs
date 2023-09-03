public class MainMenuState : BaseGameplayState
{
    private MainMenuController MainMenu { get; }

    public MainMenuState(MainMenuController mainMenu)
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