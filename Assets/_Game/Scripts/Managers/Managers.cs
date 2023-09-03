using UnityEngine;

public class Managers : MonoBehaviour
{
    public ScoreManager ScoreManager { get; private set; }
    
    public Managers Init()
    {
        DontDestroyOnLoad(gameObject);

        if (ScoreManager == null)
        {
            ScoreManager = new ScoreManager();
        }
        
        return this;
    }
}