using System;
using UnityEngine;

namespace Lesson
{
    public class Damager : MonoBehaviour
    {
        //тут может быть логика отталкивания
        [SerializeField] private float damageValue;

        private void OnCollisionEnter(Collision collision)
        {
            Health health = collision.gameObject.GetComponent<Health>();

            if (health)
            {
                health.HealthValue -= damageValue;
            }
        }
    }
}