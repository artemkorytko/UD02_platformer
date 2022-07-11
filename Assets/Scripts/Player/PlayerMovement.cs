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
   
    private bool _isCanJump;
    private bool _isActive;
    private float _maxVelocityMagnitud;

    protected override void Start()
    {
        base.Start();
        _rigidbody = GetComponent<Rigidbody2D>();
        _isCanJump = true;
        _isActive = true;
        //скорост по у во 2ую степень + скорость по х во 2ую степень и возвести в квадрат - получили max velocity(gipotenus)
        _maxVelocityMagnitud = Mathf.Sqrt(Mathf.Pow(jumpImpulse, 2f) + Mathf.Pow(speed, 2f));
    }

    protected override void Update()
    {
        if(!_isActive) return;
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
        //SimpleInput плагин, загружен с package manager вмемсто Input юнити, считывает движение со стрелок и WAD
        float horizontalAxis = SimpleInput.GetAxis(HORIZONTAL);
        //текущая скорость
        Vector2 velocity = _rigidbody.velocity;
        //скорость по Х
        velocity.x = horizontalAxis * speed;
        //присваиваем измененное значение
        _rigidbody.velocity = velocity;
        //если равен 0, то возвращаем 0, если не равен и значение отрицательное вернет знак -, если зн. положительноне знак +
        _animationController.SetSpeedDirection(velocity.x == 0 ? 0 : (int)Mathf.Sign(velocity.x));
    }

    private void VerticalMovement()
    {
        if (_isCanJump && SimpleInput.GetAxis(VERTICAL) > 0)
        {
            _isCanJump = false;
            //apply force to rigidbody, направление вверх, импульсом(разовый толчок)
            _rigidbody.AddForce(jumpImpulse * Vector2.up, ForceMode2D.Impulse);
            
            if (_animationController is PlayerAnimationController anim)
            {
                //anim jump is working
                anim.DoJump();
            }
           // PlayerAnimationController anim = _animationController as PlayerAnimationController;
        }
    }
    
    //ограничение скорость движения - не двигаться  > max скорости
    private void ClampVelocity()
    {
        //длина вектора скорости
        float velocityMagnitude = _rigidbody.velocity.magnitude;
        //диапазон от мин зн. 0 до макс. зн. velocityMagnitude
        velocityMagnitude = Mathf.Clamp(velocityMagnitude, 0, _maxVelocityMagnitud);
        //обновляем значение - velocity приводим к 1 и * на 
        _rigidbody.velocity = _rigidbody.velocity.normalized * velocityMagnitude; 
    }

    private void UpdateSide()
    {
        bool isNeedUpdate = Mathf.Abs(_rigidbody.velocity.x) > 0f;
        if (!isNeedUpdate) return;
        //отрицательное или положителльное зн. скорости
        float side = Math.Sign(_rigidbody.velocity.x);
        //текуущий скейл
        Vector2 localScale = transform.localScale;
        //если знаки по х разные
        if (Math.Sign(localScale.x) != side)
        {
            localScale.x *= -1;
        }
        //обновить значение
        transform.localScale = localScale;
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

    //коллизия с платформами
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (!_isActive) return;

        if (col.gameObject.TryGetComponent(out PlatformComponet platformComponet))
        {
            _isCanJump = true;
        }
    }

}