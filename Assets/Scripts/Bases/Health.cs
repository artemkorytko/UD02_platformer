using System;
using UnityEngine;

public class Health : MonoBehaviour
{
     [SerializeField] private float maxHealth;
     private float _currentHealth;

     public float MaxHealth => maxHealth;
     public event Action OnDie;
     public event Action OnHealthChanged;

     public float HealthValue
     {
          get => _currentHealth;
          set
          {
               _currentHealth = Mathf.Clamp(value, 0, maxHealth);
               OnHealthChanged?.Invoke();
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
          HealthValue = 0f;
     }
}