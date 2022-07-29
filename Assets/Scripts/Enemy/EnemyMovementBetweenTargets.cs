using Base;
using UnityEngine;

namespace Enemy
{
    public class EnemyMovementBetweenTargets : BaseMovement
    {
        [SerializeField] private Transform startPosition;
        [SerializeField] private Transform targetPosition;

        private Transform _currentTarget;

        protected override void Start()
        {
            base.Start();
            _currentTarget = targetPosition;
        }

        protected override void Movement()
        {
            Vector2 direction = (_currentTarget.position - transform.position).normalized;
            //distance in frame
            float moveDistance = speed * Time.deltaTime;
            //check distance to goal(target-point)
            float distanceToTarget = Vector2.Distance(_currentTarget.position, transform.position);
            if (moveDistance > distanceToTarget)
            {
                moveDistance = distanceToTarget;
                _currentTarget = _currentTarget == targetPosition ? startPosition : targetPosition;
            }
            transform.Translate(direction * moveDistance);
            _animationController.SetSpeedDirection((int)Mathf.Sign(direction.x));
            UpdateSpriteSide((int)Mathf.Sign(direction.x));
        }
        
        private void UpdateSpriteSide(int side)
        {
            //save current local-scale
            Vector2 localScale = transform.localScale;
            //look to the left
            if (Mathf.Sign(localScale.x) != side)
            {
                localScale.x *= -1;
            }

            transform.localScale = localScale;
        }
    }
}