using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Lesson
{
    public class CameraController: MonoBehaviour
    {
        [SerializeField] private float damping = 2f;
        [SerializeField] private Vector2 offset = new Vector2(2f, 1f);

        private Transform _target;
        private bool faceLeft;
        private int lastX;
        private Camera _camera;

        public void Initialize(Transform target)
        {
            _target = target;
            FindPlayer();
        }

        private void FindPlayer()
        {
            var position = _target.position;
            lastX = Mathf.RoundToInt(position.x);
            transform.position = new Vector2(position.x + offset.x, position.y + offset.y);
        }

        private void LateUpdate()
        {
            if(!_target) return;
            var position = _target.position;
            int currentX = Mathf.RoundToInt(position.x);
            if (currentX > lastX)
            {
                faceLeft = false;
            }
            else if (currentX < lastX)
            {
                faceLeft = true;
            }
            
            lastX = Mathf.RoundToInt(position.x);

            var target = faceLeft ? new Vector2(position.x - offset.x, position.y - offset.y) : new Vector2(position.x + offset.x, position.y + offset.y);

            transform.position = Vector2.Lerp(transform.position, target, damping * Time.deltaTime);
        }
    }
}