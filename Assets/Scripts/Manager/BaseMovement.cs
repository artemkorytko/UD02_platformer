using UnityEngine;
using System;
namespace Manager
{
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
}

  
