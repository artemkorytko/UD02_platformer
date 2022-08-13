using Platformer;
using UI;
using UnityEngine;
using UnityEngine.UI;

namespace Player
{
    public class PlayerMovementController : BaseMovementController
    {
        //private const string HORIZONTAL = "Horizontal";
        private UIManager _uiManager;
        private Button _jumpButton;
        private Joystick _joystick;
        private Rigidbody2D _rb;

        private void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _uiManager = FindObjectOfType<UIManager>();
        }
        

        private void Update()
        {
            Movement();
        }
        
        
        protected override void Movement()
        {
            _joystick = _uiManager.PlayerJoystick;
            _jumpButton = _uiManager.PlayerJumpButton;
            float horizontalAxis;
            horizontalAxis = _joystick.Horizontal;
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