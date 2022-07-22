using System;
using DefaultNamespace;
using UnityEngine;

namespace Lesson.Player
{
    public class PlayerMovement : BaseMovement
    {
        private const string HORIZONTAL = "Horizontal";
        private const string VERTICAL = "Vertical";

        [SerializeField] private float jumpImpulse = 5f;
        private Rigidbody2D rigidbody;
        private bool _isCanJump = true;
        private bool _isActive = true;
        private float _maxVelocityMagnitude;

        protected override void Start()
        {
            base.Start();
            rigidbody = GetComponent<Rigidbody2D>();
            _maxVelocityMagnitude = Mathf.Sqrt(Mathf.Pow(jumpImpulse, 2f) + Mathf.Pow(speed, 2));
        }

        protected override void Update()
        {
            if(!_isActive) return;
            
            base.Update();
            CheckSide();
        }

        private void CheckSide()
        {
            bool isNeedUpdate = Mathf.Abs(rigidbody.velocity.x) > 0;
            if(!isNeedUpdate) return;
            int side = (int) Mathf.Sign(rigidbody.velocity.x);
            UpdateSide(side);
        }

        protected override void Movement()
        {
            HorizontalMovement();
            VerticalMovement();
            ClampVelocity();
        }

        private void ClampVelocity()
        {
            float velocityMagnitude = rigidbody.velocity.magnitude;
            velocityMagnitude = Mathf.Clamp(velocityMagnitude, 0, _maxVelocityMagnitude);
            rigidbody.velocity = rigidbody.velocity.normalized * velocityMagnitude;
        }

        private void VerticalMovement()
        {
            if (_isCanJump && SimpleInput.GetAxis(VERTICAL) > 0)
            {
                _isCanJump = false;
                rigidbody.AddForce(jumpImpulse * Vector2.up, ForceMode2D.Impulse);

                if (_animationController is PlayerAnimationController anim)
                {
                    anim.DoJump();
                }
            }
        }

        private void HorizontalMovement()
        {
            float horizontalAxis =  SimpleInput.GetAxis(HORIZONTAL);
            Vector2 velocity = rigidbody.velocity;
            velocity.x = horizontalAxis * speed;
            rigidbody.velocity = velocity;
            _animationController.SetSpeedDirection(velocity.x == 0 ? 0: (int) Mathf.Sign(velocity.x));
        }

        public void SetActive(bool isActive)
        {
            _isActive = isActive;
            if (_isActive == false) rigidbody.velocity = Vector2.zero;
        }

        public void OnDie()
        {
            _animationController.SetDeath();
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            if(!_isActive) return;

            var platform = col.gameObject.GetComponent<PlatformComponent>();
            if (platform)
            {
                _isCanJump = true;
            }
        }
    }
}