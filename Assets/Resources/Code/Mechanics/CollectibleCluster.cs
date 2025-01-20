using System.Collections.Generic;
using UnityEngine;

public class CollectibleCluster : MonoBehaviour
{
    private CollectibleContainer collectibleContainer;
    private HashSet<Collectible> collectibles;

    private int collectibleCount = 0;    

    public void Init(CollectibleContainer collectibleContainer)
    {
        this.collectibleContainer = collectibleContainer;
        this.collectibleContainer.OnRemovedCollectible += OnRemovedCollectible;

        collectibles = new();
    }

    public static CollectibleCluster Create(CollectibleContainer collectibleContainer)
    {
        var gameObject = new GameObject("CollectibleCluster");
        var instance = Instantiate(gameObject, collectibleContainer.transform);
        var collectibleCluster = instance.AddComponent<CollectibleCluster>();

        collectibleCluster.Init(collectibleContainer);

        return collectibleCluster;
    }

    public void AddCollectible(Collectible collectible)
    {
        var isCollectibleAdded = collectibles.Add(collectible);

        if (isCollectibleAdded)
        {
            ++collectibleCount;
        }
    }

    private void OnRemovedCollectible(Collectible collectible)
    {
        var isLastCollectibleRemoved = collectibles.Remove(collectible) &&
                                       collectibles.Count == 0;
        if (isLastCollectibleRemoved)
        {
            collectibleContainer.TryCombineCollectibles(collectibleCount, collectible.transform.position);
            Destroy(gameObject);
        }
    }
}
