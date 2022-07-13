using System;
using SimpleInputNamespace;
using UnityEngine;

public abstract class BaseMovement : MonoBehaviour
{
    [SerializeField] protected float speed = 5f;

    protected BaseAnimationController _animationController;

    protected virtual void Start()
    {
        _animationController = GetComponent<BaseAnimationController>();
    }

    protected virtual void Update()
    {
        Movement();
    }

    protected abstract void Movement();
    
    protected void UpdateSide(int side)
    {
        var localScale = transform.localScale;
        if (Mathf.Sign(localScale.x) != side)
        {
            localScale.x *= -1;
        }
        
        transform.localScale = localScale;
    }
}
