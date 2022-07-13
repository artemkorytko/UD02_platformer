using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Manager
{
    public class PlayerController : MonoBehaviour
    {
        private PlayerMovement _movement;
        private Health _health;
        private bool _isActive=true;
        public event Action OnWin;
        public event Action OnDead;
        public event Action OnCoinCollected;

        private void Start()
        {
            _movement = GetComponent<PlayerMovement>();
            _health = GetComponent<Health>();
            _health.OnDie += OnDie;
        }

        private void OnDestroy()
        {
            _health.OnDie -= OnDie;
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (!_isActive) return;

            Coin coin = collision.gameObject.GetComponent<Coin>();

            if (coin != null)
            {
                coin.gameObject.SetActive(false);
                OnCoinCollected?.Invoke();
                
            }

            
            if (collision.GetComponent<Finish>())
            {
                Deactivate();
                //_animationController.SetSpeedDirection(0);
                StartCoroutine(DelayCall(OnWin, 2f));
            }
        }

        private void Deactivate()
        {
            _isActive = false;
            _movement.SetActive(false);
        }  
        private IEnumerator DelayCall(System.Action action, float delay)
        {
            yield return new WaitForSeconds(delay);
            action?.Invoke();
        }
        
        private void OnDie()
        {
            _movement.OnDie();
            StartCoroutine(DelayCall(OnDead, 2f));
            Deactivate();
        }
    }
}