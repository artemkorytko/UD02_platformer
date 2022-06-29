using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : BaseMovement
{
    [SerializeField] private float jumpImpulse = 5f;
    private Rigidbody2D _rigidbody;
    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";
    private bool _isCanJump;
    private float _maxVelocityMagnitude;
    private bool _isActive;

    protected override void Start()
    {
        base.Start();
        _isCanJump = true;
        _rigidbody = GetComponent<Rigidbody2D>();
        _maxVelocityMagnitude = Mathf.Sqrt(Mathf.Pow(jumpImpulse, 2f) + Mathf.Pow(speed, 2));
    }

    protected override void Update()
    {
        if (!_isActive) return;

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
        float horizontalAxis = SimpleInput.GetAxis(HORIZONTAL);
        Vector2 velocity = _rigidbody.velocity;
        velocity.x = horizontalAxis * speed;
        _rigidbody.velocity = velocity;
        _animationController.SetSpeedDirection(velocity.x == 0 ? 0 : (int)Mathf.Sign(velocity.x));
    }

    private void VerticalMovement()
    {
        if (_isCanJump && SimpleInput.GetAxis(VERTICAL) > 0)
        {
            _isCanJump = false;
            _rigidbody.AddForce(jumpImpulse * Vector2.up, ForceMode2D.Impulse);

            if (_animationController is PlayerAnimationController anim)
            {
                anim.DoJump();
            }
        }
    }

    private void ClampVelocity()
    {
        float velocityMagnitude = _rigidbody.velocity.magnitude;
        velocityMagnitude = Mathf.Clamp(velocityMagnitude, 0, _maxVelocityMagnitude);
        _rigidbody.velocity = _rigidbody.velocity.normalized * velocityMagnitude;
    }

    private void UpdateSide()
    {
        bool isNeedUpdate = Mathf.Abs(_rigidbody.velocity.x) > 0f;
        if (!isNeedUpdate) return;

        float side = Mathf.Sign(_rigidbody.velocity.x);
        Vector2 localScale = transform.localScale;
        if(Mathf.Sign(localScale.x) != side)
        {
            localScale.x *= -1;
        }
        transform.localScale = localScale;
    }

    public void SetActive(bool isActive)
    {
        _isActive = isActive;
        if(_isActive == false)
        {
            _rigidbody.velocity = Vector2.zero;
            _animationController.SetSpeedDirection(0);
        }
    }

    public void OnDie()
    {
        _animationController.SetDeath();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(!_isActive) return;

        var platform = collision.gameObject.GetComponent<PlatformaComponent>();
        if(platform)
        {
            _isCanJump = true;
        }
    }
}
