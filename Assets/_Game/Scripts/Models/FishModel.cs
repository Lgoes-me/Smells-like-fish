using UnityEngine;

[CreateAssetMenu(fileName = "Fish", menuName = "Data/Fish", order = 1)]
public class FishModel : ScriptableObject
{
    public int minDepth;
    public int maxDepth;
    
    public int mainScore;
    public int secondaryScore;

    public int hardness; 
    public BaitType bait;
}
