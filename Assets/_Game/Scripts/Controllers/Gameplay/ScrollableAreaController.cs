using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class ScrollableAreaController : MonoBehaviour
{
    [field: SerializeField] private PlayerController PlayerPrefab { get; set; }
    [field: SerializeField] private EnemyGroupController[] EnemyGroupsPrefabs { get; set; }

    private Action<IScrollable> SubscribeScrollable { get; set; }
    private PlayerController Player { get; set; }
    private Coroutine SpawnCoroutine { get; set; }
    
    public ScrollableAreaController Init(Action<IScrollable> subscribeScrollable)
    {
        SubscribeScrollable = subscribeScrollable;
        gameObject.SetActive(false);
        return this;
    }

    public void Show()
    {
        Player = Instantiate(PlayerPrefab, 
            new Vector3(0,3f, 0), 
            Quaternion.identity, 
            transform).Init(this);
        
        SubscribeScrollable(Player);

        gameObject.SetActive(true);
        SpawnCoroutine = StartCoroutine(SpawnEnemiesCoroutine());
    }

    private IEnumerator SpawnEnemiesCoroutine()
    {
        yield return new WaitForSeconds(3f);
        
        while (gameObject.activeInHierarchy)
        {
            var enemyGroup = Instantiate(
                EnemyGroupsPrefabs[Random.Range(0, EnemyGroupsPrefabs.Length)], 
                new Vector3(0,-5.5f, 0), 
                Quaternion.identity, 
                transform).Init();
            
            SubscribeScrollable(enemyGroup);
            yield return new WaitForSeconds(Random.Range(1, 2.5f));
        }
    }

    public void OnFishCaught()
    {
        StopCoroutine(SpawnCoroutine);
        GameController.Game.ChangeState<CaughtFishState>();
    }
    
    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void GetToSurface()
    {
        Player.transform.parent = null;
        GameController.Game.ChangeState<ScoreState>();
    }
}
