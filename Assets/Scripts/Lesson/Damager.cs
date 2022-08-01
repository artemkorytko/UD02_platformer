using System;
using UnityEngine;
using DG.Tweening;

namespace Lesson
{
    public class Damager : MonoBehaviour
    {
        //тут может быть логика отталкивания
        [SerializeField] private int damageValue;
        [SerializeField] private float jumpPower = 1.5f;

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Health health = collision.gameObject.GetComponent<Health>();
            
            if (health)
            {
                Repulsion(collision);
                health.HealthValue -= damageValue;
            }
        }

        private void Repulsion(Collision2D collision)
        {
            var player = collision.gameObject.transform;
            var position = player.position;
            var endValue = gameObject.transform.localScale.x >= 0 ? 
                new Vector2(position.x + 1.5f, position.y - 0f) : new Vector2(position.x - 1.5f, position.y - 0f);
            
            player.DOJump(endValue, jumpPower, 1, 0.75f, false);
        }
    }
}