using UnityEngine;

namespace Manager
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private float damping = 2f;
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
            var position = new Vector3(_target.position.x,_target.position.y ,-10);
            position.z = -10;
            _lastX = Mathf.RoundToInt(position.x);
            transform.position = new Vector2(position.x + offset.x, position.y + offset.y);
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
                target = new Vector3(position.x - offset.x, position.y + offset.y,-10);
            }
            else
            {
                target = new Vector3(position.x + offset.x, position.y + offset.y,-10);
            }

            transform.position = Vector2.Lerp(transform.position, target, damping * Time.deltaTime);
        }
    }
}
