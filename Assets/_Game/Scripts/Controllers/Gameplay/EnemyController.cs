using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private EnemyGroupController EnemyGroup { get; set; }
    
    public int MainScore { get; private set; }
    public int SecondaryScore { get; private set; }
    
    public void Init(EnemyGroupController enemyGroup)
    {
        EnemyGroup = enemyGroup;
        
        MainScore = 10;
        SecondaryScore = 1;
    }

    public void OnCaught()
    {
        EnemyGroup.OnFishCaught();
    }
}