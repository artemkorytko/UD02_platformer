using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Platformer
{
    public class Enemy : MonoBehaviour
    {
        public bool isAlive = true;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.TryGetComponent<Player.Player>(out Player.Player player))
            {
                isAlive = false;
            }
        }
    }
}