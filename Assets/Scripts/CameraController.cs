using UnityEngine;

namespace Platformer
{
    public class CameraController : MonoBehaviour
    {
        [SerializeField] private float damping = 2f;  // "то с какой мы себя догоняем"
        [SerializeField] private Vector2 offset = new Vector2(2f, 1f);

        private Transform _target;
        private bool _faceLeft;
        private int _lastXPosition;
        private Camera _camera;
        private float _dynamicSpeed;

        public void Initialize(Transform target)
        {
            _target = target;
            FindPlayer();
        }

        private void FindPlayer()
        {
            _lastXPosition = Mathf.RoundToInt(_target.position.x);
            transform.position = new Vector2(_target.position.x + offset.x, _target.position.y + offset.y);
        }

        private void LateUpdate()
        {
            if (_target = null) return;
            int currentX = Mathf.RoundToInt(_target.position.x);
            if (currentX > _lastXPosition)
            {
                _faceLeft = false;
            }
            else if (currentX < _lastXPosition)
            {
                _faceLeft = true;
            }

            _lastXPosition = Mathf.RoundToInt(_target.position.x);

            Vector2 target;
            // if (_faceLeft)
            // {
            //     target = new Vector2(position.x - offset.x, position.y);
            // }
            // else
            // {
            //     target = new Vector2.Lerp(transform.position, target, damping * Time.deltaTime);
            // }
        }
    }
}