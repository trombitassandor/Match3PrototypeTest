using UnityEngine;

public class CollectEffectCreator : MonoBehaviour, ICollectible
{
    [SerializeField] private GameObject collectEffectPrefab;

    private CollectibleContainer collectibleContainer;
    private bool isCollected;

    public void Init(CollectibleContainer collectibleContainer)
    {
        this.collectibleContainer = collectibleContainer;
    }

    public void TryCollect()
    {
        if (!isCollected)
        {
            isCollected = true;
            CreateCollectEffect();
        }
    }

    private void CreateCollectEffect()
    {
        var parent = collectibleContainer.transform;
        var rotation = transform.rotation;
        var position = transform.position;

        Instantiate(collectEffectPrefab, position, rotation, parent);
    }
}
