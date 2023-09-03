using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private EnemyGroupController EnemyGroup { get; set; }
    
    public void Init(EnemyGroupController enemyGroup)
    {
        EnemyGroup = enemyGroup;
    }

    public void OnCaught()
    {
        EnemyGroup.OnFishCaught();
    }
}