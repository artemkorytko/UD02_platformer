using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Lesson
{
    public class CameraController: MonoBehaviour
    {
        [SerializeField] private float damping = 2f;
        [SerializeField] private Vector3 offset = new Vector3(2f, 1f, -10f);

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
            transform.position = new Vector3(position.x + offset.x, position.y + offset.y, -10f);
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

            var target = faceLeft ? new Vector3(position.x - offset.x, position.y + offset.y, -10f) : new Vector3(position.x + offset.x, position.y + offset.y, -10f);

            transform.position = Vector3.Lerp(transform.position, target, damping * Time.deltaTime);
        }
    }
}