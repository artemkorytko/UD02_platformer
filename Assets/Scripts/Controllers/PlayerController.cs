using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerMovement _moveMent;
    private Health _health;

    private bool _isActive;

    public event Action OnWin;
    public event Action OnDead;
    public event Action OnCoinCollected;

    private void Start()
    {
        _moveMent = GetComponent<PlayerMovement>();
        _health = GetComponent<Health>();
        _health.OnDie += OnDie;
        Activate();
    }

    private void OnDestroy()
    {
        _health.OnDie += OnDie;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!_isActive) return;

        CoinComponent coin = collision.GetComponent<CoinComponent>();

        if(coin)
        {
            coin.gameObject.SetActive(false);
            OnCoinCollected?.Invoke();
            return;
        }

        if(collision.GetComponent<FinishComponent>())
        {
            Deactivate();
            StartCoroutine(DelayCall(OnWin, 2));
        }
    }
    private void Activate()
    {
        _isActive = true;
        _moveMent.SetActive(true);
    }

    private void Deactivate()
    {
        _isActive = false;
        _moveMent.SetActive(false);
    }

    private IEnumerator DelayCall(Action action, float delay)
    {
        yield return new WaitForSeconds(delay);
        action?.Invoke();
    }

    private void OnDie()
    {
        _moveMent.OnDie();
        StartCoroutine(DelayCall(OnDie, 2));
        Deactivate();
    }
}

