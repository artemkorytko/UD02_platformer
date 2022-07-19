using System;
using System.Collections;
using Components;
using DefaultNamespace;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerMovement _movement;
    private Health _health;
   
    private bool _isActive;
    public event Action OnWin;
    public event Action OnDeath;
    public event Action OnCoinCollected;

    private void Start()
    {
        _movement = GetComponent<PlayerMovement>();
        _health = GetComponent<Health>();
        
        _health.OnDie += OnDiePLayer;
        Activate();
    }

    private void OnDestroy()
    {
        _health.OnDie -= OnDiePLayer;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!_isActive) return;
        if (col.gameObject.TryGetComponent(out CoinComponent coin))

        {
            coin.gameObject.SetActive(false);
            if (OnCoinCollected != null) OnCoinCollected.Invoke();
        }

        if (col.gameObject.TryGetComponent(out FinishComponent finishComponent))
        {
            Deactivate();
            var delayCall = DelayCall(OnWin, 2f);
            StartCoroutine(delayCall);
        }

        if (col.gameObject.TryGetComponent(out AbyssComponent abyssComponent))
        {
            Deactivate();
            var delayCall = DelayCall(OnDiePLayer, 0.1f);
            StartCoroutine(delayCall);
        }
    }

    private void Deactivate()
    {
        _isActive = false;
        _movement.SetActive(false);
    }

    private void Activate()
    {
        _isActive = true;
        _movement.SetActive(true);
    }

    private void OnDiePLayer()
    {
        _movement.OnDieAnimation();
        Deactivate();
        StartCoroutine(DelayCall(OnDeath, 2f));
    }

    private IEnumerator DelayCall(Action action, float delay)
    {
        yield return new WaitForSeconds(delay);
        action?.Invoke();
    }
}