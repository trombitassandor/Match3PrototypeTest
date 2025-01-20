using System;
using UnityEngine;

public class CollectibleContainer : MonoBehaviour
{
    [SerializeField] private CollectibleCombinationContainer collectibleCombinationContainer;

    public Action<Collectible> OnRemovedCollectible;
    public Action OnCollecting;

    public bool HasSpace => currentCollectibleCount < maxCollectibleCount;

    private uint maxCollectibleCount;
    private uint currentCollectibleCount;

    public void Init(uint maxCollectibleCount)
    {
        this.maxCollectibleCount = maxCollectibleCount;
    }

    public void AddCollectible(Collectible collectible)
    {
        ++currentCollectibleCount;
        collectible.Init(this);
    }

    public void TryCombineCollectibles(int collectibleCount, Vector2 position)
    {
        var prefab = collectibleCombinationContainer.GetCombinedCollectible(collectibleCount);

        if (prefab != null)
        {
            var instance = Instantiate(prefab, position, Extensions.GetRandomRotation(), transform);
            AddCollectible(instance);
        }        
    }

    public void RemoveCollectible(Collectible collectible)
    {
        --currentCollectibleCount;
        Destroy(collectible.gameObject);
        OnRemovedCollectible?.Invoke(collectible);
    }

    public void TriggerCollecting()
    {
        OnCollecting?.Invoke();
    }
}
