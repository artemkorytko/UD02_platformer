using UnityEngine;

namespace Manager
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private float damping = 2f;
        [SerializeField] private Vector3 offset = new Vector3(2f, 1f,-10f);

        private Transform _target;
        private bool _faceLeft;
        private int _lastX;
        private Camera _targetCamera;
        public void Initialize(Transform target)
        {
            _target = target;
            FindPlayer();
        }

        private void FindPlayer()
        {
            var position = _target.position;
            _lastX = Mathf.RoundToInt(position.x);
            transform.position = new Vector3(position.x + offset.x, position.y + offset.y,position.z+ offset.z);
        }

        private void LateUpdate()
        {
            if (!_target) return;
            
            var position = _target.position;
            int currentX = Mathf.RoundToInt(position.x);
            if (currentX > _lastX)
            {
                _faceLeft = false;
            }
            else if (currentX < _lastX)
            {
                _faceLeft = true;
            }

            _lastX = Mathf.RoundToInt(position.x);

            Vector2 target;
            if (_faceLeft)
            {
                target = new Vector3(position.x - offset.x, position.y + offset.y,position.z+offset.z);
            }
            else
            {
                target = new Vector3(position.x + offset.x, position.y + offset.y,position.z+offset.z);
            }

            transform.position = Vector2.Lerp(transform.position, target, damping * Time.deltaTime);
        }
    }
}
