using UnityEngine;

public class PlayerMovement : BaseMovement
{
    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";
    
    [SerializeField] private float jumpImpulse = 5f;
    private Rigidbody2D _rigidbody;
    private bool _isCanJump;
    private bool _isActive;
    private float _maxVelocityMagnitude;

    protected override void Start()
    {
        base.Start();
        _isCanJump = true;
        _rigidbody = GetComponent<Rigidbody2D>();
        _maxVelocityMagnitude = Mathf.Sqrt(Mathf.Pow(jumpImpulse, 2f) + Mathf.Pow(speed, 2f));
    }

    protected override void Update()
    {
        if (!_isActive) return;
        
        base.Update();
        CheckSide();
    }
    
    protected override void Movement()
    {
        HorizontalMovement();
        VerticalMovement();
        ClampVelocity();
    }

    private void HorizontalMovement()
    {
        var horizontalAxis = SimpleInput.GetAxis(HORIZONTAL);
        var velocity = _rigidbody.velocity;
        velocity.x = horizontalAxis * speed;
        _rigidbody.velocity = velocity;
        if (_isCanJump)
        {
            _animationController.SetSpeedDirection(velocity.x == 0 ? 0 : (int)Mathf.Sign(velocity.x));
        }
        else
        {
            _animationController.SetSpeedDirection(0);
        }
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
        var velocityMagnitude = _rigidbody.velocity.magnitude;
        velocityMagnitude = Mathf.Clamp(velocityMagnitude, 0, _maxVelocityMagnitude);
        _rigidbody.velocity = _rigidbody.velocity.normalized * velocityMagnitude;
    }

    private void CheckSide()
    {
        bool isNeedUpdate = Mathf.Abs(_rigidbody.velocity.x) > 0f;
        if (!isNeedUpdate) return;
        var side = Mathf.Sign(_rigidbody.velocity.x);
        UpdateSide((int)side);
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
        _animationController.SetDeathAnimation();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (!_isActive) return;

        var platform = col.gameObject.GetComponent<PlatformComponent>();

        if (platform)
        {
            _isCanJump = true;
        }
    }
}
