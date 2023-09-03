using System;
using UnityEngine;

[CreateAssetMenu(fileName = "Bait", menuName = "Data/Bait", order = 1)]
public class BaitModel : ScriptableObject
{
    public BaitType type;
}

[Flags]
public enum BaitType
{
    None = 0,
    Worm = 1,
    Meat = 2,
    Ration = 4 
}
