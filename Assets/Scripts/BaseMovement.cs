using System;
using SimpleInputNamespace;
using UnityEngine;

public abstract class BaseMovement : MonoBehaviour
{
    [SerializeField] protected float speed = 5f;

    protected BaseAnimationController _animationController;

    private void Start()
    {
        _animationController = GetComponent<BaseAnimationController>();
    }

    protected virtual void Update()
    {
        Movement();
    }

    protected abstract void Movement();
}
