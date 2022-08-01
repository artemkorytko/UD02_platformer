using Unity.VisualScripting;
using UnityEngine;

namespace Lesson.Enemy
{
    public class EnemyMovement : BaseMovement
    {
        [SerializeField] private Transform startPosition;
        [SerializeField] private Transform targetPosition;

        private Transform _currentTarget;

        protected override void Start()
        {
            base.Start();
            _currentTarget = targetPosition;
        }

        // ReSharper disable Unity.PerformanceAnalysis
        protected override void Movement()
        {
            Vector2 direction = (_currentTarget.position - transform.position).normalized;
            float moveDistance = speed * Time.deltaTime;
            float distanceToTarget = Vector2.Distance(_currentTarget.position, transform.position);

            if (moveDistance > distanceToTarget)
            {
                moveDistance = distanceToTarget;
                
                if (_currentTarget == targetPosition)
                {
                    _currentTarget = startPosition;
                }
                else
                {
                    _currentTarget = targetPosition;
                }
            }
            
            transform.Translate((direction * moveDistance));
            _animationController.SetSpeedDirection((int)Mathf.Sign(direction.x));

            UpdateSide((int)Mathf.Sign(direction.x));
        }

        private void UpdateSide(int side)
        {
            Vector2 localScale = transform.localScale;
            if (Mathf.Sign(localScale.x) != side)
            {
                localScale.x *= -1;
            }

            transform.localScale = localScale;
        }
    }
}