using System.Collections;
using System.Collections.Generic;
using Manager;
using Player;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerMovement : BaseMovement
{
    [SerializeField] private float jumpImpuls;
    
    private  const  string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vetrical";

    private Rigidbody2D _rigidbody;
    private bool _isCunJamp;
    private float _maxVelicityMagnitude;
    private bool _isActive;
    private bool _isCanJump;
    protected override void Start()
    { 
        base.Start();
        _rigidbody = GetComponent<Rigidbody2D>();
        _maxVelicityMagnitude = Mathf.Sqrt(Mathf.Pow(jumpImpuls, 2f) + Mathf.Pow(speed, 2f));
    }

    protected override void Update()
    {
        if (!_isActive) return;
        base.Update();
        CheckSide();
    }

    private void CheckSide()
    {
        bool isNeedUpdate = Mathf.Abs(_rigidbody.velocity.x) > 0;
        if(!isNeedUpdate)return;
        int side = (int)Mathf.Sign(_rigidbody.velocity.x);
        UpdateSide(side);
    }

    protected override void Movement()
    {
        HorizontalMovement();
        VertikalMovement();
        ClampVelosity();
    }

    private void HorizontalMovement()
    {
        float horizontalAxis = SimpleInput.GetAxis(HORIZONTAL);
        Vector2 velocity = _rigidbody.velocity;
        velocity.x = horizontalAxis * speed;
        _rigidbody.velocity = velocity;
        _animationController.SetSpeedDirection(velocity.x==0?0:(int)Mathf.Sign(velocity.x));

    }

    private void VertikalMovement()
    {
        if (_isCunJamp && SimpleInput.GetAxis(VERTICAL) > 0)
        {
            _isCunJamp = false;
            _rigidbody.AddForce(jumpImpuls*Vector2.up, ForceMode2D.Impulse);

            if (_animationController is PlayerAnimationController anim)
            {
                anim.DoJump();
            }
            
        }
    }

    public void SetActive(bool isActive)
    {
        _isActive = isActive;
        if (_isActive == false)
        {
            _rigidbody.velocity = Vector2.zero;
            _animationController.SetSpeedDirection(0);
        }
    }

    public void OnDie()
    {
        _animationController.SetDeath();
    }
    private void ClampVelosity()
    {
        float velosityMagnitude = _rigidbody.velocity.magnitude;
        velosityMagnitude = Mathf.Clamp(velosityMagnitude, 0, _maxVelicityMagnitude);
        _rigidbody.velocity = _rigidbody.velocity.normalized * velosityMagnitude;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!_isActive) return;

        PlatformController platform = collision.gameObject.GetComponent<PlatformController>();

        if (platform != null)
        {
            _isCanJump = true;
        }
    }



    
}
