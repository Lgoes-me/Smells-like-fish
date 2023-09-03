using UnityEngine;

public class Application : MonoBehaviour
{
    public ScoreService ScoreService { get; private set; }
    
    public Application Init()
    {
        DontDestroyOnLoad(gameObject);

        if (ScoreService == null)
        {
            ScoreService = new ScoreService();
        }
        
        return this;
    }
}