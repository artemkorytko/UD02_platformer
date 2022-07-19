using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float damping = 2f;

    [SerializeField] private Vector3 offset = new(2f, 1f);

    //точка, за которой камера наблюдает
    private Transform _target;

    //check look to the left?
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