using System;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float damping = 2;
    [SerializeField] private Vector2 offset = new Vector2(2f, 1f);

    private Transform _target;
    private bool _faceLeft;
    private int _lastX;

    public void Initialize(Transform target)
    {
        _target = target;
        FindPlayer();
    }

    private void FindPlayer()
    {
        _lastX = Mathf.RoundToInt(_target.position.x);
        transform.position = new Vector2(_target.position.x + offset.x, _target.position.y + offset.y);
    }

    private void LateUpdate()
    {
        if (!_target) return;
        int currentX = Mathf.RoundToInt(_target.position.x);
        if (currentX > _lastX)
        {
            _faceLeft = false;
        }
        else if (currentX < _lastX)
        {
            _faceLeft = true;
        }

        _lastX = Mathf.RoundToInt(_target.position.x);

        Vector2 target;
        if (_faceLeft)
        {
            target = new Vector2(_target.position.x - offset.x, _target.position.y + offset.y );
        }
        else
        {
            target = new Vector2(_target.position.x + offset.x, _target.position.y + offset.y );
        }

        transform.position = Vector2.Lerp(transform.position, target, damping * Time.deltaTime);
    }
}
