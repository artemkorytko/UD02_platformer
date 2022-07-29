using System.Collections.Generic;
using UnityEngine;

namespace Managers
{
    public class LevelManager : MonoBehaviour
    {
        [SerializeField] private List<GameObject> levels;

        private GameObject _currentlevel;

        public PlayerController PlayerController { get; private set; }

        public void InitialiseLevel(int index)
        {
            if (levels.Count == 0)
            {
                return;
            }

            if (_currentlevel != null)
            {
                Destroy(_currentlevel);
            }

            index = index / levels.Count >= 1 ? index % levels.Count : index;

            _currentlevel = Instantiate(levels[index], transform);
            PlayerController = _currentlevel.GetComponentInChildren<PlayerController>();
        }
    }
}