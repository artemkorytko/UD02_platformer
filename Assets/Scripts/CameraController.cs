using System;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float damping = 2f;
    [SerializeField] private Vector2 offset = new Vector2(2f, 2f);

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
        var position = _target.position;
        _lastX = Mathf.RoundToInt(position.x);
        transform.position = new Vector2(position.x + offset.x, position.y + offset.y);
    }

    private void LateUpdate()
    {
        var position = _target.position;
        
        if (!_target) return;
        
        var currentX = Mathf.RoundToInt(_target.position.x);

        if (currentX > _lastX)
        {
            _faceLeft = false;
        }
        else if (currentX < _lastX)
        {
            _faceLeft = true;
        }

        _lastX = Mathf.RoundToInt(_target.position.x);

        Vector2 moveTo;
        if (_faceLeft)
        {
            moveTo = new Vector2(position.x - offset.x, position.y + offset.y);
        }
        else
        {
            moveTo = new Vector2(position.x + offset.x, position.y + offset.y);
        }

        transform.position = Vector2.Lerp(transform.position, moveTo, damping * Time.deltaTime);
    }
}