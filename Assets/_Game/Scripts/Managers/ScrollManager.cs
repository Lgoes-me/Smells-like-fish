using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class ScrollManager : MonoBehaviour
{
    [field: SerializeField] private Camera Camera { get; set; }

    [field: SerializeField] private Gradient GradientColor { get; set; }
    [field: SerializeField] private SpriteRenderer Background { get; set; }
    
    [field: SerializeField] private ScrollableAreaController ScrollableArea { get; set; }
    [field: SerializeField] private DepthController Depth { get; set; }
    
    private int ScrollSpeed { get; set; }
    private List<IScrollable> Scrollables { get; set; }
    
    private int CurrentDepth { get; set; }

    public ScrollManager Init()
    {
        Scrollables = new List<IScrollable>();
        
        ScrollableArea.Init(SubscribeScrollable);
        Depth.Init();
        
        return this;
    }

    public void Show()
    {
        Camera.transform.DOMove(new Vector3(0,0,-10), 2.5f).OnComplete(() =>
        {
            ScrollableArea.Show();
            Depth.Show();
        });
    }

    public void Hide()
    {
        Camera.transform.DOMove(new Vector3(0,9,-10), 1f).OnComplete(() =>
        {
            Depth.Hide();
            ScrollableArea.Hide();
        });
    }
    
    public void UpdateScrollSpeed(int scrollSpeed)
    {
        ScrollSpeed = scrollSpeed;
        
        foreach (var scrollable in Scrollables)
        {
            scrollable.ScrollSpeed = ScrollSpeed;
        }
    }
    
    private void SubscribeScrollable(IScrollable scrollable)
    {
        scrollable.ScrollSpeed = ScrollSpeed;
        Scrollables.Add(scrollable);
    }
    
    private void FixedUpdate()
    {
        CurrentDepth += ScrollSpeed;
        
        var percent = CurrentDepth / 10000f;
        Background.color = GradientColor.Evaluate(percent);
        
        Depth.UpdateTextAndColor(CurrentDepth, GradientColor.Evaluate(1 - percent));
        
        if (CurrentDepth < -1)
        {
            ScrollableArea.GetToSurface();
        }
    }
}

public interface IScrollable
{
    int ScrollSpeed { get; set; }
}