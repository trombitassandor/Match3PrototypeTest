using UnityEditor;
using UnityEngine;

public class CreateCollectibleSpawnerMenuItem : MonoBehaviour
{
    [MenuItem("GameObject/Create CollectibleSpawner", false, -10)]
    public static void Create()
    {
        if (Selection.activeGameObject != null)
        {
            var collectibleSpawner = Resources.Load<CollectibleSpawner>("Prefabs/Spawner");
            var parent = Selection.activeGameObject.transform;
            Instantiate(collectibleSpawner, parent);
        }
    }
}
