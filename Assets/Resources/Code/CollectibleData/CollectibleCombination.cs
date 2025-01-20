using System;
using UnityEngine;

[Serializable]
public class CollectibleCombination
{
    [SerializeField] private uint collectibleCount;
    [SerializeField] private Collectible combinedCollectible;

    public uint CollectibleCount => collectibleCount;
    public Collectible CombinedCollectible => combinedCollectible;
}
