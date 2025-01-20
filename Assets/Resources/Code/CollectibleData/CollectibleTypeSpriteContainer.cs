using System.Linq;
using UnityEngine;

[CreateAssetMenu(
    fileName = "CollectibleTypeSpriteContainer", 
    menuName = "ScriptableObjects/CollectibleTypeSpriteContainer", order = 1)]
public class CollectibleTypeSpriteContainer : ScriptableObject
{
    [SerializeField] 
    private CollectibleTypeSpritePair[] collectibleTypeSpritePairs 
        = new CollectibleTypeSpritePair[0];

    public Sprite GetSpriteByCollectibleType(CollectibleType collectibleType)
    {
        var collectibleTypeSpritePair = collectibleTypeSpritePairs.First(
            collectibleSpritePair => collectibleSpritePair.CollectibleType == collectibleType);

        return collectibleTypeSpritePair.Sprite;
    }
}
