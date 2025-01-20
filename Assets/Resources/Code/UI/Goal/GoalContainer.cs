using System.Collections.Generic;
using UnityEngine;

public class GoalContainer : MonoBehaviour
{
    [SerializeField] private GoalElement goalElementPrefab;
    [SerializeField] private CollectibleTypeSpriteContainer collectibleTypeSpriteContainer;

    private Dictionary<CollectibleType, GoalElement> goalElementByCollectibleType = new();

    public void Init(IEnumerable<Goal> goals)
    {
        goals.ForEach(CreateGoalElement);
    }

    public void TryDecreaseGoalAmount(CollectibleType collectibleType)
    {
        var hasGoalOfCollectibleType = goalElementByCollectibleType
            .TryGetValue(collectibleType, out var goalElement);

        if (hasGoalOfCollectibleType)
        {
            goalElement.TryDecreaseAmount();
        }
    }

    private void CreateGoalElement(Goal goal)
    {
        var goalElement = Instantiate(goalElementPrefab, transform);
        var goalSprite = collectibleTypeSpriteContainer
            .GetSpriteByCollectibleType(goal.CollectibleType);

        goalElement.Init(goalSprite, goal.Amount);

        goalElementByCollectibleType.Add(goal.CollectibleType, goalElement);
    }
}
