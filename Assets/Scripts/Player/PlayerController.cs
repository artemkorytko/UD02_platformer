using System;
using System.Collections;
using Base;
using Components;
using UnityEngine;

public class PlayerController : BaseClass
{
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private GameObject downRayObject;
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
        
        //если здоровье 0
        _health.OnDie += OnDiePLayer;
        Activate();
    }

    private void Update()
    {
        DamageToEnemy();
    }

    private void OnDestroy()
    {
        _health.OnDie -= OnDiePLayer;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (!_isActive) return;
        
        if (col.gameObject.TryGetComponent(out CoinComponent coin))
        {
            coin.gameObject.SetActive(false);
            OnCoinCollected?.Invoke();
        }

        if (col.gameObject.TryGetComponent(out FinishComponent finishComponent))
        {
            Deactivate();
            var delayCall = DelayCall(OnWin, 2f);
            StartCoroutine(delayCall);
        }

        if (col.gameObject.TryGetComponent(out AbyssComponent abyssComponent))
        {
            var delayCall = DelayCall(OnDiePLayer, 0.1f);
            StartCoroutine(delayCall);
            OnDestroy();
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

    private void DamageToEnemy()
    {
        RaycastHit2D hit = Physics2D.Raycast(downRayObject.transform.position, -Vector2.up, 0.3f, layerMask);
        Collider2D hitCollider = hit.collider;
        if (hitCollider != null)
        {
            BaseClass damageOwner = hitCollider.GetComponent<BaseClass>();

            if (damageOwner != null)
            {
                damageOwner.GetDamage(damage);
            }
            Debug.DrawRay(downRayObject.transform.position, -Vector2.up * hit.distance, Color.yellow);
        }
    }

    private IEnumerator DelayCall(Action action, float delay)
    {
        yield return new WaitForSeconds(delay);
        action?.Invoke();
    }
}