using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour, ICollectible
{
    [SerializeField] private CollectibleType collectibleType;
    [SerializeField] private CollectEffectCreator collectEffectCreator;
    [SerializeField] private uint minNeighbourCollectibleToCollect;

    private readonly List<Collectible> neighbourCollectibles = new();

    private CollectibleContainer collectibleContainer;
    private bool isCollected;

    public CollectibleType CollectibleType => collectibleType;

    public void Init(CollectibleContainer collectibleContainer)
    {
        this.collectibleContainer = collectibleContainer;
        collectEffectCreator?.Init(collectibleContainer);
    }

    public void TryCollect()
    {
        if (!isCollected)
        {
            Collect();
        }
    }

    public void TryCollect(CollectibleCluster collectibleCluster)
    {
        if (!isCollected)
        {
            isCollected = true;
            collectibleCluster.AddCollectible(this);
            TryCollectNeighbourCollectibles(collectibleCluster);
            Collect();
        }
    }

    private void Collect()
    {
        isCollected = true;
        collectEffectCreator?.TryCollect();
        collectibleContainer.RemoveCollectible(this);
    }

    private void OnMouseDown()
    {
        var isCollectable = neighbourCollectibles.Count >= minNeighbourCollectibleToCollect;

        if (isCollectable)
        {
            collectibleContainer.TriggerCollecting();
            var collectibleCluster = CollectibleCluster.Create(collectibleContainer);
            TryCollect(collectibleCluster);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        TryAddNeighbourCollectible(collision.GetComponent<Collectible>());
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        TryRemoveNeighbourCollectible(collision.GetComponent<Collectible>());
    }    

    private void TryAddNeighbourCollectible(Collectible collectible)
    {
        if (!isCollected && 
            collectible != null && 
            collectible.CollectibleType == CollectibleType && 
            !neighbourCollectibles.Contains(collectible))
        {
            neighbourCollectibles.Add(collectible);
        }
    }

    private void TryRemoveNeighbourCollectible(Collectible collectible)
    {
        if (!isCollected && 
            collectible != null && 
            neighbourCollectibles.Contains(collectible))
        {
            neighbourCollectibles.Remove(collectible);
        }
    }

    private void TryCollectNeighbourCollectibles(CollectibleCluster collectibleCluster)
    {
        neighbourCollectibles.ForEach(
            neighbourCollectible => neighbourCollectible.TryCollect(collectibleCluster));
    }
}
