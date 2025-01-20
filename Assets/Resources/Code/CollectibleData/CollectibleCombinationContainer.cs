using System.Linq;
using UnityEngine;

[CreateAssetMenu(
    fileName = "CollectibleCombinationContainer",
    menuName = "ScriptableObjects/CollectibleCombinationContainer", order = 2)]
public class CollectibleCombinationContainer : ScriptableObject
{
    [SerializeField] 
    private CollectibleCombination[] collectibleCombinations 
        = new CollectibleCombination[0];

    public Collectible GetCombinedCollectible(int collectibleCount)
    {
        var collectibleCombination = collectibleCombinations.FirstOrDefault(
            collectibleCombination => collectibleCombination.CollectibleCount <= collectibleCount);

        return collectibleCombination?.CombinedCollectible;
    }

    private void OnValidate()
    {
        if (collectibleCombinations != null)
        {
            collectibleCombinations = collectibleCombinations
                .OrderByDescending(collectibleCombination => collectibleCombination.CollectibleCount)
                .ToArray();
        }
    }
}
