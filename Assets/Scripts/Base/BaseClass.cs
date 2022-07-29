using UnityEngine;

namespace Base
{
    public class BaseClass : MonoBehaviour
    {
        [SerializeField] protected int health;
        [SerializeField] protected int damage;

        private BaseAnimationController _animationController;
        private BaseMovement _movement;

        private void Awake()
        {
            _animationController = GetComponent<BaseAnimationController>();
            _movement = GetComponent<BaseMovement>();
        }

        public void GetDamage(int getDamage)
        {
            if (health != 0)
            {
                health = -getDamage;
            }

            if (health == 0)
            {
                Death();
            }
        }

        protected virtual void Death()
        {
            _animationController.SetDeath();
            _movement.gameObject.SetActive(false);
        }
    }
}