using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private GameObject[] levels;

    private GameObject _currentlevel;

    public PlayerController PlayerController { get; private set; }

    public void InitialiseLevel(int index)
    {
        if (levels.Length == 0)
        {
            return;
        }

        if (_currentlevel != null)
        {
            Destroy(_currentlevel);
        }

        index = index % levels.Length;

        _currentlevel = Instantiate(levels[index], transform);
        PlayerController = _currentlevel.GetComponentInChildren<PlayerController>();
    }
}