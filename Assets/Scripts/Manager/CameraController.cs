/*
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
        private float _positionX;
        private float _positionY;
        public void Initialize(Transform target)
        {
            _target = target;
            _positionX = _target.position.x;
            _positionY = _target.position.y;
            FindPlayer();
        }

        private void FindPlayer()
        {
            //var position = _target.position;
            _lastX = Mathf.RoundToInt(_positionX);
            transform.position = new Vector3(_positionX + offset.x, _positionY + offset.y, offset.z);
        }

        private void LateUpdate()
        {
            //if (!_target) return;
            
            //var position = _target.position;
            int currentX = Mathf.RoundToInt(_positionX);
            if (currentX > _lastX)
            {
                _faceLeft = false;
            }
            else if (currentX < _lastX)
            {
                _faceLeft = true;
            }

            _lastX = Mathf.RoundToInt(_positionX);

            Vector2 target;
            if (_faceLeft)
            {
                target = new Vector3(_positionX - offset.x, _positionY + offset.y);
            }
            else
            {
                target = new Vector3(_positionX+ offset.x, _positionY+ offset.y);
            }

            transform.position = Vector2.Lerp(transform.position, target, damping * Time.deltaTime);
        }
    }
}
*/
using UnityEngine;
public class CameraController : MonoBehaviour
{
    [SerializeField] private float damping = 2f;
  
    [SerializeField] private Vector3 offset = new(2f, 1f);

    
    private Transform _target;
    //check lock to the left?
    private bool _faceLeft;
    //last X position
    private int _lastX;
 
    public void Initialize(Transform target)
    {
        _target = target;
        FindPlayer();
    }

    private void FindPlayer()
    {
        //var position = _target.position;
        var position = _target.position;
        //позиция камеры по Х = позиция таргета по Х
        var positionX = position.x;
        //позиция камеры по У = позиция таргета по У
        var positionY = position.y;
        //позиция камеры по Z = позиция КАМЕРЫ по z
        var positionZ = transform.position.z;
  
        _lastX = Mathf.RoundToInt(positionX);
        transform.position = new Vector3(positionX + offset.x, positionY + offset.y, positionZ + offset.z);
    }
 
    private void LateUpdate()
    {
        if (_target == null) return;
        var position = _target.position;
        var positionX = position.x;
        var positionY = position.y;
        var positionZ = transform.position.z;
  
        int currentX = Mathf.RoundToInt(positionX);
        //movement to the right
        if (currentX > _lastX)
        {
            _faceLeft = false;
        }
        //movement to the left
        else if (currentX < _lastX)
        {
            _faceLeft = true;
        }
// write down position.x
        _lastX = Mathf.RoundToInt(positionX);
  
        Vector3 targetPos;
        // MOVE TO THE LEFT
        if (_faceLeft)
        {
            targetPos = new Vector3(positionX - offset.x, positionY + offset.y, positionZ);
        }
        //MOVE TO THE RIGHT
        else
        {
            targetPos = new Vector3(positionX + offset.x, positionY + offset.y, positionZ);
        }
        //update position
        transform.position = Vector3.Lerp(transform.position, targetPos, damping * Time.deltaTime);
    }
}