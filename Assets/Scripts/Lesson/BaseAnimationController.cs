using System;
using UnityEngine;

namespace Lesson
{
    public class BaseAnimationController : MonoBehaviour
    {
        protected Animator _animator;
        private const string SPEED = "SpeedInt";
        private const string DEATH = "Dead";
        private static readonly int Speed = Animator.StringToHash(SPEED);
        private static readonly int Death = Animator.StringToHash(DEATH);

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