using System;
using UnityEngine;

namespace Manager
{
    public class Damager : MonoBehaviour
    {
        [SerializeField] private float damageValue;

        private void OnCollisionEnter2D(Collision2D col)
        {
            Health health = col.gameObject.GetComponent<Health>();

            if (health)
            {
                health.HealthValue -= damageValue;
            }
        }
    }
}