using System;
using UnityEngine;

namespace Lesson
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private int maxHealth;

        private int _currentHealth;

        public event Action OnDie;
        public event Action<int> HealthСhanged;

        public int HealthValue
        {
            get => _currentHealth;
            set
            {
                _currentHealth = Mathf.Clamp(value, 0, maxHealth);
                HealthСhanged?.Invoke(_currentHealth);
                if (_currentHealth == 0f)
                {
                    OnDie?.Invoke();
                }
            }
        }

        private void Start()
        {
            _currentHealth = maxHealth;
        }

        [ContextMenu("Set dead")]
        public void SetDead()
        {
            HealthValue = 0;
        }
    }
}