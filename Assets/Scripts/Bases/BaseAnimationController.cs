using UnityEngine;

[RequireComponent(typeof(Animator))]
public class BaseAnimationController : MonoBehaviour
{
    private const string IDLE = "Idle";
    private const string SPEED = "Speed";
    private const string DEATH = "Death";
    private static readonly int Idle = Animator.StringToHash(IDLE);
    private static readonly int Speed = Animator.StringToHash(SPEED);
    private static readonly int Death = Animator.StringToHash(DEATH);
    
    protected Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }
    
    public void SetSpeedDirection(int value)
    {
        _animator.SetInteger(Speed, value);
    }
    
    public void SetDeathAnimation()
    {
        _animator.SetTrigger(Death);
    }
    
    public void SetIdleAnimation()
    {
        _animator.SetTrigger(Idle);
    }
}
