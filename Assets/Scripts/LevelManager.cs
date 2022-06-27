using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject[] levels;

    private GameObject _currentLevel;

    public PlayerController Player { get; private set; }

    public void InstantiateLevel(int levelIndex)
    {
        if (levels.Length == 0)
        {
            return;
        }
        
        if (_currentLevel != null)
        {
            Destroy(_currentLevel);
        }

        levelIndex %= levels.Length;

        _currentLevel = Instantiate(levels[levelIndex], transform);

        Player = _currentLevel.GetComponentInChildren<PlayerController>();
    }
}