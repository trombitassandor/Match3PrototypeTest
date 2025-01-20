using System.Collections;
using System.Linq;
using UnityEngine;

public class CollectibleSpawner : MonoBehaviour
{
    [SerializeField] private WeightCollectiblePair[] weightCollectiblePairs;
    [SerializeField] private Transform forceDirection;
    [SerializeField] private float forceMultiplier = 1f;
    [SerializeField] private float cooldown = 0.3f;

    private CollectibleContainer collectiblesContainer;

    private int blockersCount;
    private bool isOnCooldown;    

    public void Init(CollectibleContainer collectiblesContainer)
    {
        this.collectiblesContainer = collectiblesContainer;

        collectiblesContainer.OnRemovedCollectible += OnRemovedCollectible;

        TrySpawnCollectible();
    }

    private void OnValidate()
    {
        if (weightCollectiblePairs != null)
        {
            foreach (var weightCollectiblePair in weightCollectiblePairs)
            {
                weightCollectiblePair.Validate();
            }
        }
    }

    private void OnDestroy()
    {
        if (collectiblesContainer != null)
        {
            collectiblesContainer.OnRemovedCollectible -= OnRemovedCollectible;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        ++blockersCount;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        --blockersCount;
        TrySpawnCollectible();
    }

    private void OnRemovedCollectible(Collectible collectible)
    {
        TrySpawnCollectible();
    }

    private void TrySpawnCollectible()
    {
        if (!isOnCooldown && 
            blockersCount == 0 && 
            collectiblesContainer.HasSpace)
        {
            StartCoroutine(StartCooldown());
            SpawnCollectible();
        }
    }

    private void SpawnCollectible()
    {
        var prefab = GetRandomCollectible();
        var position = transform.position;
        var rotation = Extensions.GetRandomRotation();
        var parent = collectiblesContainer.transform;

        var instance = Instantiate(prefab, position, rotation, parent);
        
        collectiblesContainer.AddCollectible(instance);
        KickOutCollectible(instance);
    }

    private Collectible GetRandomCollectible()
    {
        var weightTotal = weightCollectiblePairs.Sum(
            collectibleWeight => collectibleWeight.Weight);

        var randomWeight = Random.Range(0, weightTotal);

        var currentWeightTotal = 0;

        for (var i = 0; i < weightCollectiblePairs.Length; i++)
        {
            currentWeightTotal += weightCollectiblePairs[i].Weight;

            if (currentWeightTotal > randomWeight)
            {
                return weightCollectiblePairs[i].Collectible;
            }
        }

        return weightCollectiblePairs.Last().Collectible;
    }

    private void KickOutCollectible(Collectible collectible)
    {
        var rigidbody = collectible.GetComponent<Rigidbody2D>();
        var direction = forceDirection.position - transform.position;
        var force = direction.normalized * forceMultiplier;

        rigidbody.AddForce(force, ForceMode2D.Impulse);
    }

    private IEnumerator StartCooldown()
    {
        isOnCooldown = true;
        yield return new WaitForSeconds(cooldown);
        isOnCooldown = false;
        TrySpawnCollectible();
    }
}
