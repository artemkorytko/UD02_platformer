using System;
using System.Collections;
using Base;
using UnityEngine;

public class PlayerMovement : BaseMovement
{
    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";
    
    [SerializeField] private float jumpImpulse = 5f;
    private Rigidbody2D _rigidbody;
   
    private bool isCanJump;
    private bool _isActive;
    private float _maxVelocityMagnitud;

    protected override void Start()
    {
        base.Start();
        _rigidbody = GetComponent<Rigidbody2D>();
        _maxVelocityMagnitud = Mathf.Sqrt(Mathf.Pow(jumpImpulse, 2f) + Mathf.Pow(speed, 2f));
    }

    protected override void Update()
    {
        base.Update();
        UpdateSide();
    }

    protected override void Movement()
    {
        HorizontalMovement();
        VerticalMovement();
        ClampVelocity();
    }

    private void HorizontalMovement()
    {
        //SimpleInput плагин, загружен с package manager вмемсто Input юнити
        float horizontalAxis = SimpleInput.GetAxis(HORIZONTAL);
        Vector2 velocity = _rigidbody.velocity;
        velocity.x = horizontalAxis * speed;
        _rigidbody.velocity = velocity;
        _animationController.SetSpeedDirection(velocity.x == 0 ? 0 : (int)Mathf.Sign(velocity.x));
    }

    private void VerticalMovement()
    {
        if (isCanJump && SimpleInput.GetAxis(VERTICAL) > 0)
        {
            isCanJump = false;
            _rigidbody.AddForce(jumpImpulse * Vector2.up, ForceMode2D.Impulse);
            var anim = _animationController as PlayerAnimationController;
            anim.DoJump();
        }
    }
    private void ClampVelocity()
    {
        float velocityMagnitude = _rigidbody.velocity.magnitude;
        velocityMagnitude = Mathf.Clamp(velocityMagnitude, 0, _maxVelocityMagnitud);
        _rigidbody.velocity = _rigidbody.velocity.normalized * velocityMagnitude; 
    }

    private void UpdateSide()
    {
        bool isNeedUpdate = Mathf.Abs(_rigidbody.velocity.x) > 0f;
        //дописать 
        //вынести в общий класс бейзмувемент
    }

    public void SetActive(bool isActive)
    {
        _isActive = isActive;
        //
    }

    public void OnDie()
    {
        //TODO
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (!_isActive) return;

        if (col.gameObject.TryGetComponent(out PlatformComponet platformComponet))
        {
            //дописать
        }
    }

    private void Deactivate()
    {
        //
    }

    private IEnumerator DelayCall(Action action, float delay)
    {
        yield return new WaitForSeconds(delay);
        action?.Invoke();
    }
}