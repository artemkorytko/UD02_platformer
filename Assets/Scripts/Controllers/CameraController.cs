using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float damping = 2f;
    [SerializeField] private Vector3 offset = new Vector3(2f, 2f, -10f);
    [SerializeField] private float downMovingOffset = 8f;

    private Transform _target;
    private Transform _border;
    private bool _faceLeft;
    private int _lastX;

    public void Initialize(Transform target)
    {
        _target = target;
        _border = FindObjectOfType<BorderComponent>().transform;
        FindPlayer();
    }

    private void FindPlayer()
    {
        var position = _target.position;
        _lastX = Mathf.RoundToInt(position.x);
        transform.position = new Vector3(position.x + offset.x, position.y + offset.y, position.z + offset.z);
    }

    private void LateUpdate()
    {
        if (!_target) return;
        if (transform.position.y < _border.position.y + downMovingOffset) return;

        var position = _target.position;
        var currentX = Mathf.RoundToInt(position.x);
        Vector3 moveTo;

        if (currentX > _lastX)
        {
            _faceLeft = false;
        }
        else if (currentX < _lastX)
        {
            _faceLeft = true;
        }

        _lastX = Mathf.RoundToInt(_target.position.x);
        
        if (_faceLeft)
        {
            moveTo = new Vector3(position.x - offset.x, position.y + offset.y, transform.position.z);
        }
        else
        {
            moveTo = new Vector3(position.x + offset.x, position.y + offset.y, transform.position.z);
        }

        var currentPosition = Vector3.Lerp(transform.position, moveTo, damping * Time.deltaTime);
        transform.position = currentPosition;
    }
}