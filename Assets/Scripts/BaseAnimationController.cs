using SimpleInputNamespace;
using UnityEngine;

namespace Platformer
{
    public abstract class BaseAnimationController : MonoBehaviour
    {
        protected Animator _animator;

        private const string SPEED = "Speed";
        private const string DEATH = "Death";
        private static readonly int Speed = Animator.StringToHash(SPEED);
        private static readonly int Death = Animator.StringToHash(DEATH);


        private void Awake()
        {
            _animator = GetComponent<Animator>();
        }
        
        
        public void SetWalkDirection(bool isLeft)
        {
            if (isLeft)
            {
                Vector2 localScale = gameObject.transform.localScale;
                localScale.x = 1;
                transform.localScale = localScale;
            }
            else
            {
                Vector2 localScale = gameObject.transform.localScale;
                localScale.x = -1;
                transform.localScale = localScale;
            }
        }
        
        
        public void SetDeath()
        {
            _animator.SetBool("Death", true);
        }
    }
}