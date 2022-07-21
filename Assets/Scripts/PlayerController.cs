using UnityEngine;
using System;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private AnimatorController _animatorController;
    [SerializeField] private float Speed;
    [SerializeField] private float JumpHeight;
   
    private Health _health;
    private DoEffect _doEffect;
    [SerializeField]
    private int Lives = 3;
    public int lives
    {
        get { return Lives; }
        set
        {
            if (value < 3) Lives = value;
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

    public void Update()
    {
        if (Input.GetButton(Horizontal)) Move();
        if (IsJump)
        {
            if (Input.GetButtonDown(Vertical)) Jump();
        }
        _health = FindObjectOfType<Health>();
    }
    public void FixedUpdate()
    {
        if (Input.GetButton(Horizontal))
        {
            _animatorController.SetRunTrigger();
        }
        else
        {
            _animatorController.SetIdleTrigger();
        }
        if (Input.GetButtonDown(Vertical))
        {
            _animatorController.SetJumpTrigger();
        }
        
    }
    private void Move()
    {
        Vector3 HorizontalVector = Vector3.right * Input.GetAxis(Horizontal);
        transform.position = Vector3.MoveTowards(transform.position, transform.position + HorizontalVector, Speed * Time.deltaTime);

        if (Input.GetAxis(Horizontal) > 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
            
        }
        if (Input.GetAxis(Horizontal) < 0)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    private void Jump()
    {
        GetComponent<Rigidbody2D>().AddForce(transform.up * JumpHeight, ForceMode2D.Impulse);
        IsJump = false;
    }

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
            Lives = 0;
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
        lives--;
        if (Lives == 0)
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
