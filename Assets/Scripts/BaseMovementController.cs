using UnityEngine;

namespace Platformer
{
    public abstract class BaseMovementController : MonoBehaviour
    {
        [SerializeField] protected BaseAnimationController _animationController;
        [SerializeField] protected float speed = 5f;
        //protected BaseAnimationController _animationController;
        
        // private void Start()
        // {
        //     _animationController = gameObject.GetComponent<BaseAnimationController>();
        // }

        
        protected abstract void Movement();
    }
}