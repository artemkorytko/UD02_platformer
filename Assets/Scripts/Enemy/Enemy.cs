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
            if (collision.gameObject.TryGetComponent<Player>(out Player player))
            {
                isAlive = false;
            }
        }
    }
}