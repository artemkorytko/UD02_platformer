using UnityEngine;

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
    
    protected override void Movement()
    {
        Vector2 currentTargetPosition = _currentTarget.position;
        Vector2 position = transform.position;
        var direction = (currentTargetPosition - position).normalized;
        var moveDistance = speed * Time.deltaTime;
        var distanceToTarget = Vector2.Distance(currentTargetPosition, position);

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
        
        transform.Translate(direction * moveDistance);
        
        if (UpdateSide((int)Mathf.Sign(direction.x)))
        {
            _animationController.SetSpeedDirection((int)Mathf.Sign(direction.x));
        }
    }
}
