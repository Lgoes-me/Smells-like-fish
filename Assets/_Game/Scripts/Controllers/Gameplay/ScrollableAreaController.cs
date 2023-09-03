using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class ScrollableAreaController : MonoBehaviour, IScrollable
{ 
    [field: SerializeField] private ScoreController Score { get; set; }
    [field: SerializeField] private Gradient GradientColor { get; set; }
    [field: SerializeField] private SpriteRenderer Background { get; set; }
    
    [field: SerializeField] private PlayerController PlayerPrefab { get; set; }
    [field: SerializeField] private EnemyGroupController[] EnemyGroupsPrefabs { get; set; }
    [field: SerializeField] private GameObject DepthCanvas { get; set; }
    [field: SerializeField] private TextMeshProUGUI DepthText { get; set; }
    
    public int ScrollSpeed { get; set; }
    
    private List<IScrollable> Scrollables { get; set; }
    private PlayerController Player { get; set; }
    private Coroutine SpawnCoroutine { get; set; }
    
    private int Depth { get; set; }
    
    public void Awake()
    {
        Scrollables = new List<IScrollable>();
        
        Player = Instantiate(PlayerPrefab, 
            new Vector3(0,3f, 0), 
            Quaternion.identity, 
            transform).Init(this);
        
        SubscribeScrollable(Player);
        
        gameObject.SetActive(false);
        DepthCanvas.gameObject.SetActive(false);
    }

    private void SubscribeScrollable(IScrollable scrollable)
    {
        scrollable.ScrollSpeed = ScrollSpeed;
        Scrollables.Add(scrollable);
    }
    
    public void Show()
    {
        gameObject.SetActive(true);
        DepthCanvas.SetActive(true);
    }
    
    public void UpdateScrollSpeed()
    {
        foreach (var scrollable in Scrollables)
        {
            scrollable.ScrollSpeed = ScrollSpeed;
        }
    }

    public void SpawnEnemies()
    {
        SpawnCoroutine = StartCoroutine(SpawnEnemiesCoroutine());
    }

    private IEnumerator SpawnEnemiesCoroutine()
    {
        while (gameObject.activeInHierarchy)
        {
            var enemyGroup = Instantiate(
                EnemyGroupsPrefabs[Random.Range(0, EnemyGroupsPrefabs.Length)], 
                new Vector3(0,-5.5f, 0), 
                Quaternion.identity, 
                transform).Init();
            
            SubscribeScrollable(enemyGroup);
            
            yield return new WaitForSeconds(Random.Range(1, 4f));
        }
    }

    public void StopSpawn()
    {
        StopCoroutine(SpawnCoroutine);
    }
    
    public void OnFishCaught()
    {
        GameController.Game.ChangeState(new CaughtFishState(this));
    }
    
    public void Hide()
    {
        gameObject.SetActive(false);
        DepthCanvas.SetActive(false);
    }

    private void FixedUpdate()
    {
        Depth += ScrollSpeed;
        var percent = Depth / 5000f;
        Background.color = GradientColor.Evaluate(percent);
        
        DepthText.SetText($"{Depth}");
        DepthText.color = GradientColor.Evaluate(1 - percent);
        
        if (Depth < -1)
        {
            GameController.Game.ChangeState(new ScoreState(Score, Player));
        }
    }
}

public interface IScrollable
{
    int ScrollSpeed { get; set; }
}