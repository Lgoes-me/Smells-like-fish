using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PlayerController : MonoBehaviour, IScrollable
{
    public int ScrollSpeed { get; set; }

    private ScrollableAreaController ScrollableArea { get; set; }
    private bool IsDragging { get; set; }
    private Camera Camera { get; set; }
    private List<EnemyController> Enemies { get; set; }

    public PlayerController Init(ScrollableAreaController scrollableArea)
    {
        ScrollableArea = scrollableArea;
        IsDragging = false;
        Camera = Camera.main;
        Enemies = new List<EnemyController>();

        return this;
    }

    private void Update()
    {
        if (!IsDragging)
        {
            if (!(transform.position.y < 4.5f)) return;
            if (!(transform.position.y > -4.5f)) return;

            transform.position += 0.5f * ScrollSpeed * Time.deltaTime * Vector3.up;
            return;
        }

#if UNITY_EDITOR
        if (Input.mousePosition.x < 0.1f) return;
        if (Input.mousePosition.y < 0.1f) return;
        if (Input.mousePosition.x >= Handles.GetMainGameViewSize().x - 1) return;
        if (Input.mousePosition.y >= Handles.GetMainGameViewSize().y - 1) return;
#else
        if (Input.mousePosition.x < 0.1f) return;
        if (Input.mousePosition.y < 0.1f) return;
        if (Input.mousePosition.x >= Screen.width - 1) return;
        if (Input.mousePosition.y >= Screen.height - 1) return;
#endif

        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 10;
        var worldPosition = Camera.ScreenToWorldPoint(mousePos);

        transform.position = new Vector3(worldPosition.x, worldPosition.y, 0);
    }

    private void OnMouseDown()
    {
        IsDragging = true;
    }

    private void OnMouseUp()
    {
        IsDragging = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<EnemyController>(out var enemy))
        {
            if (Enemies.Count == 0)
            {
                ScrollableArea.OnFishCaught();
                GameController.Game.Application.ScoreService.AddCurrentScore(enemy.MainScore);
            }
            else
            {
                GameController.Game.Application.ScoreService.AddCurrentScore(enemy.SecondaryScore);
            }

            enemy.transform.parent = transform;
            enemy.OnCaught();

            enemy.transform.position = transform.position;

            Enemies.Add(enemy);
        }
    }
}