using Platformer;

namespace Player
{
    public class PlayerAnimationController : EnemyAnimationController
    {
        private const string JUMP = "Jump";
        
        //private static readonly int Jump1 = _animator.StringToHash(JUMP);

        public void DoJump()
        {
            animator.SetTrigger(JUMP);
        }
    }
}