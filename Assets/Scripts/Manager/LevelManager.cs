using UnityEngine;

namespace Manager
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private GameObject[] levels;

        private GameObject _currentLevel;
        
        public PlayerController Player { get; private set; }

        public void InstantiateLevel(int index)
        {
            if (levels.Length==0) return;
            if (_currentLevel!= null)
            {
                Destroy(_currentLevel);
            }

            index %= levels.Length;
            
            _currentLevel = Instantiate(levels[index],transform);
            Player = _currentLevel.GetComponentInChildren<PlayerController>();
        }
    }
}