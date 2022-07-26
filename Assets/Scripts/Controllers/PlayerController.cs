using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private AnimatorController _animatorController;
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpHeight;
    

    private Rigidbody2D _rigidBody;
    private Health _health;
    private DoEffect _doEffect;

    private float _maxVelocityMagnitude = 0f;
    private int lives = 3;
    public int Lives
    {
        get { return lives; }
        set
        {
            if (value < 3) lives = value;
            _health.Refresh();
        }
    }

    public event Action OnDied;
    public event Action OnFinish;
    public event Action OnGold;

    private string Horizontal = "Horizontal";
    private string Vertical = "Vertical";

    private bool IsJump = true;


    private void Awake()
    {
        _doEffect = GetComponent<DoEffect>();
    }
    private void Start()
    {
        _maxVelocityMagnitude = Mathf.Sqrt(Mathf.Pow(_jumpHeight, 2f) + Mathf.Pow(_speed, 2f));
        _rigidBody = GetComponent<Rigidbody2D>();
    }
    public void Update()
    {
        //if (Input.GetButton(Horizontal)) Move();
        //if (IsJump)
        //{
        //    if (Input.GetButtonDown(Vertical)) Jump();
        //}
        Movement();
        UpdateSide();
        _health = FindObjectOfType<Health>();
    }
 
    private void Movement()
    {
        HorizontalMovement();
        VerticalMovement();
        ClampVelocity();
    }

    private void HorizontalMovement()
    {
        float horizontalAxis = SimpleInput.GetAxis(Horizontal);
        Vector3 velocity = _rigidBody.velocity;
        velocity.x = horizontalAxis * _speed;
        _rigidBody.velocity = velocity;

        if (velocity.x == 0)
        {
            _animatorController.SetIdleTrigger();
        }
        else 
        {
            _animatorController.SetRunTrigger();
        }
        
    }
    private void VerticalMovement()
    {
        if (IsJump && SimpleInput.GetAxis(Vertical) > 0)
        {
            _rigidBody.AddForce(_jumpHeight * Vector3.up, ForceMode2D.Impulse);
            _animatorController.SetJumpTrigger();
            IsJump = false;
        }
    }
    private void ClampVelocity()
    {
        float velocityMagnitude = _rigidBody.velocity.magnitude;
        velocityMagnitude = Mathf.Clamp(velocityMagnitude, 0f, _maxVelocityMagnitude);
        _rigidBody.velocity = _rigidBody.velocity.normalized * velocityMagnitude;
    }
    private void UpdateSide()
    {
        bool isNeedUpdate = Mathf.Abs(_rigidBody.velocity.x) > 0f ? true : false;
        if (!isNeedUpdate) return;

        float side = Mathf.Sign(_rigidBody.velocity.x);
        Vector3 localScale = transform.localScale;
        if (Mathf.Sign(localScale.x) != side)
        {
            localScale.x *= -1f;
        }

        transform.localScale = localScale;
    }
    //private void Move()
    //{
    //    Vector3 HorizontalVector = Vector3.right * Input.GetAxis(Horizontal);
    //    transform.position = Vector3.MoveTowards(transform.position, transform.position + HorizontalVector, Speed * Time.deltaTime);

    //    if (Input.GetAxis(Horizontal) > 0)
    //    {
    //        GetComponent<SpriteRenderer>().flipX = false;

    //    }
    //    if (Input.GetAxis(Horizontal) < 0)
    //    {
    //        GetComponent<SpriteRenderer>().flipX = true;
    //    }
    //}

    //private void Jump()
    //{
    //    GetComponent<Rigidbody2D>().AddForce(transform.up * JumpHeight, ForceMode2D.Impulse);
    //    IsJump = false;
    //}

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<GoldComponent>()) //использовать Compairtag // а вообще нельзя юззать ничего, использовать компоненты
        {
            OnGold?.Invoke();
            Debug.Log("Gold +1");
        }

        if (other.gameObject.GetComponent<FinishComponent>())
        {
            Win();
        }

        if (other.gameObject.GetComponent<DeadColCompanent>())
        {
            lives = 0;
            OnDied?.Invoke();
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyController>())
        {
            _doEffect.DoAnimation();
            Died();
        }

        if (collision.gameObject.GetComponent<PlaneComponent>())
        {
            IsJump = true;
        }
    }
    private void Died()
    {
        Lives--;
        if (lives == 0)
        {
            OnDied?.Invoke();
            Debug.Log("Game Over");
        }
    }
    private void Win()
    {
        OnFinish?.Invoke();
        Debug.Log("You Win");
    }
}
