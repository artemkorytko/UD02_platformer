using System;
using DefaultNamespace;
using UnityEngine;

namespace Base
{
    public class DamageDiller : MonoBehaviour
    {
        [SerializeField] private float damageValue;

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.TryGetComponent(out Health health))
            {
                health.HealthValue -= damageValue;
            }
        }
    }
}