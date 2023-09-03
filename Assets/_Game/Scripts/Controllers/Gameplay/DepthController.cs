using TMPro;
using UnityEngine;

public class DepthController : MonoBehaviour
{
    [field: SerializeField] private TextMeshProUGUI DepthText { get; set; }
    
    public DepthController Init()
    {
        gameObject.SetActive(false);
        return this;
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }  
    
    public void UpdateTextAndColor(int depth, Color color)
    {
        DepthText.SetText($"{depth}");
        DepthText.color = color;
    }
}