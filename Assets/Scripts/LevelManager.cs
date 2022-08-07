using System.Diagnostics;
using Unity.VisualScripting;
using UnityEngine;

namespace Platformer
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private GameObject[] levels;
        private GameObject _currentLevel;
        public Player Player { get; private set; }
        // задаваться может только внутри
        
        
        
        public void InstantiateLevel(int levelIndex)
        {
            if (levels.Length == 0 )
            {
                return;
            }
            
            
            if (_currentLevel != null)
            {
                Destroy(_currentLevel);
            }
            
            
            //зациклили оборот уровней через остаток от деления
            levelIndex %= levels.Length;
            _currentLevel = Instantiate(levels[levelIndex], transform);
            Player = _currentLevel.GetComponentInChildren<Player>();
        }
    }
}