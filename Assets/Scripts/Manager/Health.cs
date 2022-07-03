using System;
using UnityEngine;

namespace Manager
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private float maxHealth;
        public event Action OnDie;
        private float _currentHealth;
        public float HealthValue
        {
            get
            {
                return _currentHealth;
            }

            set
            {
                _currentHealth = Mathf.Clamp(value, 0f, maxHealth);
                if (_currentHealth == 0f) OnDie?.Invoke();
            }
        }
        private void Start()
        {
            _currentHealth = maxHealth;
        }

        [ContextMenu("Set dead")]
        public void SetDead()
        {
            HealthValue = 0f;
        }
    }
}