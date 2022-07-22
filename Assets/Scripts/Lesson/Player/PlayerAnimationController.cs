using System;
using UnityEngine;

namespace Lesson.Player
{
    public class PlayerAnimationController: BaseAnimationController
    {
        private const string JUMP = "Jump";
        private static readonly int Jump = Animator.StringToHash(JUMP);

        public void DoJump()
        {
            _animator.SetTrigger(Jump);
        }
    }
}