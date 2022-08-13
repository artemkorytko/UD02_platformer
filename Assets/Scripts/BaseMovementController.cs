using Platformer;
using UnityEngine;

public abstract class BaseMovementController : MonoBehaviour
{
    [SerializeField] protected float speed = 5f;
    protected BaseAnimationController _animationController;
        
     private void Start()
     {
         _animationController = gameObject.GetComponent<BaseAnimationController>();
     }

        
    protected abstract void Movement();
}