using System;
using UnityEngine;

[Serializable]
public class WeightCollectiblePair
{
    [SerializeField] private int weight;
    [SerializeField] private Collectible collectible;

    public int Weight => weight;
    public Collectible Collectible => collectible;

    public void Validate()
    {
        weight = Mathf.Max(1, Weight);
    }
}
