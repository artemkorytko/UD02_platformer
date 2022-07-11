using System;
using System.Collections;
using DefaultNamespace;
using DefaultNamespace.Components;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerMovement _movement;
    private Health _health;

    private bool _iaActive;
    public event Action OnWin;
    public event Action OnDeath;
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
        if (!_iaActive) return;
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
    }

    private void Deactivate()
    {
        _iaActive = false;
        _movement.SetActive(false);
    }

    private void Activate()
    {
        _iaActive = true;
        _movement.SetActive(true);
    }

    private IEnumerator DelayCall(Action action, float delay)
    {
        yield return new WaitForSeconds(delay);
        action?.Invoke();
    }

    private void OnDie()
    {
        _movement.OnDie();
        StartCoroutine(DelayCall(OnDie, 2f));
        Deactivate();
    }
}