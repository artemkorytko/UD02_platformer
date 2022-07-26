using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private float Speed;
    [SerializeField] Transform startPosition;
    [SerializeField] Transform targetPosition;

    private Transform _currentTarget;

    private void Start()
    {
        _currentTarget = targetPosition;
    }
    private void Update()
    {
        Move();
    }

    private void Move()
    {

        Vector2 direction = (_currentTarget.position - transform.position).normalized;
        float moveDistance = Speed * Time.deltaTime;
        float distanceToTarget = Vector2.Distance(_currentTarget.position, transform.position);

        if (moveDistance > distanceToTarget)
        {
            moveDistance = distanceToTarget;

            if (_currentTarget == targetPosition)
            {
                GetComponent<SpriteRenderer>().flipX = true;
                _currentTarget = startPosition;
            }
            else
            {
                _currentTarget = targetPosition;
                GetComponent<SpriteRenderer>().flipX = false;
            }
        }

        transform.Translate(direction * moveDistance);
    }
}
