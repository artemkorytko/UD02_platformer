using System.Collections;
using System.Collections.Generic;
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
}
