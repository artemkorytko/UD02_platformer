using System;
using System.Collections;
using Lesson.Player;
using Unity.VisualScripting;
using UnityEngine;

namespace Lesson
{
    public class PlayerController: MonoBehaviour
    {
        private PlayerMovement _movement;
        private Health _health;

        private bool _isActive;
        
        public event Action OnWin;
        public event Action OnDead;
        public event Action OnCoinCollected;

        private void Start()
        {
            _movement = GetComponent<PlayerMovement>();
            _health = GetComponent<Health>();
            _health.OnDie += OnDie;
            Activate();
        }

        private void OnDestroy()
        {
            _health.OnDie -= OnDie;
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if(!_isActive) return;

            CoinComponent coin = col.GetComponent<CoinComponent>();

            if (coin)
            {
                coin.gameObject.SetActive(false);
                OnCoinCollected?.Invoke();
                return;
            }

            if (col.GetComponent<FinishComponent>())
            {
                Deactivate();
                StartCoroutine(DelayCall(OnWin, 2));
            }
        }

        private IEnumerator DelayCall(Action action, float delay)
        {
            yield return new WaitForSeconds(delay);
            action?.Invoke();
        }
        
        private void Activate()
        {
            _isActive = true;
            _movement.SetActive(true);
        }

        private void Deactivate()
        {
            _isActive = false;
            _movement.SetActive(false);
        }
        
        private void OnDie()
        {
            _movement.OnDie();
            StartCoroutine(DelayCall(OnDead, 2));
            Deactivate();
        }
    }
}