using System;
using UnityEngine;

namespace Platformer
{
    public abstract class BaseAnimationController : MonoBehaviour
    {
        private const string SPEED = "Speed";
        private const string DEATH = "Death";

        private static readonly int Speed = Animator.StringToHash(SPEED);
        private static readonly int Death = Animator.StringToHash(DEATH);

        protected Animator _animator;

        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }

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