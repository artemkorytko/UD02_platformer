using System;
using UnityEngine;

namespace DefaultNamespace
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private float maxHealth = 3f;

        private float _currentHelth;

        public event Action OnDie;

        public float HealthValue
        {
            get => _currentHelth;

            set
            {
                //здоровье не может быть отрицательным и больше макс
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
        
        [ContextMenu("Set dead")]
        public void SetDead()
        {
            //для разных проверок, например проверить анимацию смерти
           // HealthValue = 0f;
        }
    }
}