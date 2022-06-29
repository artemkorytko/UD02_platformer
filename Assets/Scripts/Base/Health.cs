using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private float maxHealth;

        private float _currentHelth;

        private event Action OnDie;

        public float HealthValue
        {
            get => _currentHelth;

            set
            {
                _currentHelth = Mathf.Clamp(value, 0, maxHealth);
                if (_currentHelth == 0f)
                {
                    OnDie?.Invoke();
                }
            }
        }

        private void Start()
        {
            _currentHelth = maxHealth;
        }
        
    }
}