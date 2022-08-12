using UnityEngine;

namespace Platformer
{
    public class PlayerMovementController : BaseMovementController
    {
        //private const string HORIZONTAL = "Horizontal";
        private Joystick _joystick;
        private Rigidbody2D _rb;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _joystick = FindObjectOfType<Joystick>();
        }

        private void Update()
        {
            Movement();
        }
        protected override void Movement()
        {
            float horizontalAxis = _joystick.Horizontal;
            Vector2 velocity = _rb.velocity; 
            velocity.x = speed * horizontalAxis;
            _rb.velocity = velocity;
            if (velocity.x > 0)
            {
                _animationController.SetWalkDirection(false);
            }
            else if(velocity.x < 0)
            {
                _animationController.SetWalkDirection(true);
            }

        }
        
    }
}