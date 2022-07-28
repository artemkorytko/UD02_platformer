using System;
using System.Collections;
using UnityEngine;

[RequireComponent(typeof(PlayerMovement), typeof(Health))]
public class PlayerController : MonoBehaviour
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!_isActive) return;

        if (collision.TryGetComponent(out BorderComponent _))
        {
            OnDie();
        }
        
        if (collision.TryGetComponent(out CoinComponent coin))
        {
            coin.gameObject.SetActive(false);
            OnCoinCollected?.Invoke();
            return;
        }

        if (collision.TryGetComponent(out FinishComponent _))
        {
            Deactivate();
            StartCoroutine(DelayCall(OnWin,2f));
        }
    }

    private void OnDie()
    {
        _movement.OnDie();
        StartCoroutine(DelayCall(OnDead, 2f));
        Deactivate();
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

    private IEnumerator DelayCall(Action callback, float delay)
    {
        yield return new WaitForSeconds(delay);
        callback?.Invoke();
    }
}
