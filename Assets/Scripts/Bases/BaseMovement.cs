using UnityEngine;

[RequireComponent(typeof(BaseAnimationController))]
public abstract class BaseMovement : MonoBehaviour
{
    [SerializeField] protected float speed = 5f;

    protected BaseAnimationController animationController;

    protected virtual void Start()
    {
        animationController = GetComponent<BaseAnimationController>();
    }

    protected virtual void Update()
    {
        Movement();
    }

    protected abstract void Movement();
    
    protected bool UpdateSide(int side)
    {
        var isSideUpdated = false;
        
        var localScale = transform.localScale;
        if ((int)Mathf.Sign(localScale.x) != side)
        {
            localScale.x *= -1;
            isSideUpdated = true;
        }
        
        transform.localScale = localScale;
        return isSideUpdated;
    }
}
