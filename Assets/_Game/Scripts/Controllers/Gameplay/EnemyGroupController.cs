using System.Collections.Generic;
using UnityEngine;

public class EnemyGroupController : MonoBehaviour, IScrollable
{
    [field: SerializeField] private List<EnemyController> EnemyControllers { get; set; }
    [field: SerializeField] private Animator Animator { get; set; }
    
    public int ScrollSpeed { get; set; }

    public EnemyGroupController Init()
    {
        foreach (var enemy in EnemyControllers)
        {
            enemy.Init(this);
        }

        var info = Animator.runtimeAnimatorController.animationClips[0];
        Animator.Play("DefaultState", 0, Random.Range(0, info.length));
        
        return this;
    }
    
    private void Update()
    {
        transform.position +=  ScrollSpeed * Time.deltaTime * Vector3.up;
    }

    public void OnFishCaught()
    {
        var info = Animator.GetCurrentAnimatorStateInfo(0);
        Animator.Rebind();
        Animator.Play(info.fullPathHash, 0, info.normalizedTime);
    }
}