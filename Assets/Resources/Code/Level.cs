using UnityEngine;

public class Level : MonoBehaviour
{
    [SerializeField] private uint maxCollectibleCount;
    [SerializeField] private uint movesAmount;
    [SerializeField] private Goal[] goals = new Goal[0];

    private CollectibleContainer collectibleContainer;
    private GoalContainer goalContainer;
    private MovesGui movesGui;

    private void Start()
    {
        collectibleContainer = GetComponentInChildren<CollectibleContainer>();
        collectibleContainer.Init(maxCollectibleCount);
        collectibleContainer.OnRemovedCollectible += OnRemovedCollectible;
        collectibleContainer.OnCollecting += OnCollecting;

        goalContainer = GetComponentInChildren<GoalContainer>();
        goalContainer.Init(goals);

        movesGui = GetComponentInChildren<MovesGui>();
        movesGui.Init(movesAmount);

        var tileSpawners = GetComponentsInChildren<CollectibleSpawner>();
        tileSpawners.ForEach(tileSpawner => tileSpawner.Init(collectibleContainer));
    }

    private void OnDestroy()
    {
        if (collectibleContainer != null)
        {
            collectibleContainer.OnRemovedCollectible -= OnRemovedCollectible;
            collectibleContainer.OnCollecting -= OnCollecting;
        }
    }

    private void OnRemovedCollectible(Collectible collectible)
    {
        goalContainer.TryDecreaseGoalAmount(collectible.CollectibleType);        
    }

    private void OnCollecting()
    {
        movesGui.TryDecreaseMoves();
    }
}
