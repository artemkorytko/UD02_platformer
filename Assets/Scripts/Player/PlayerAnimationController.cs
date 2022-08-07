using UnityEngine;

namespace Platformer
{
    public class PlayerAnimationController : EnemyAnimationController
    {
        private const string JUMP = "Jump";
        
        private static readonly int Jump1 = Animator.StringToHash(JUMP);

        public void DoJump()
        {
            _animator.SetTrigger(Jump1);
        }
    }
}