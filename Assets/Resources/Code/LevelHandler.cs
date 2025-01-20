using UnityEngine;

public class LevelHandler : MonoBehaviour
{
    [SerializeField] private Level[] levels;

    private Level currentLevel;
    private int currentLevelIndex;

    private void Start()
    {
        currentLevel = Instantiate(levels[currentLevelIndex]);
    }

    public void SetNextLevel()
    {
        Destroy(currentLevel.gameObject);
        currentLevelIndex = (currentLevelIndex + 1) % levels.Length;
        currentLevel = Instantiate(levels[currentLevelIndex]);
    }
}
