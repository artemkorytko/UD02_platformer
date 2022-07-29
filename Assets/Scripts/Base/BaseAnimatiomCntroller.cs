using UnityEngine;

namespace Base
{
    public abstract class BaseAnimationController : MonoBehaviour
    {
        protected Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

        private const string SPEED = "Speed";
        private const string DEATH = "Death";
        private static readonly int Speed = Animator.StringToHash(SPEED);
        private static readonly int Death = Animator.StringToHash(DEATH);

        public void SetSpeedDirection(int value)
        {
            _animator.SetInteger(Speed, value);
        }

        public void SetDeath()
        {
            _animator.SetBool(Death, true);
        }
    }
}