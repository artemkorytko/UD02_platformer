
using UnityEngine;

public class CameraController : MonoBehaviour
{
 [SerializeField] private float damping = 2f;
  
 [SerializeField] private Vector2 offset = new Vector2(2f, 1f);

 //точка, за которой камера наблюдает
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
  var position = _target.position;
  _lastX = Mathf.RoundToInt(position.x);
  transform.position = new Vector2(position.x + offset.x, position.y + offset.y);
 }
 
 private void LateUpdate()
 {
  if (_target == null) return;
  var position = _target.position;
  int currentX = Mathf.RoundToInt(position.x);
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
  _lastX = Mathf.RoundToInt(position.x);
  
  Vector2 targetPos;
  if (_faceLeft)
  {
   targetPos = new Vector2(position.x - offset.x, position.y + offset.y);
  }
  else
  {
   targetPos = new Vector2(position.x + offset.x, position.y + offset.y);
  }
  //update position
  transform.position = Vector2.Lerp(transform.position, targetPos, damping * Time.deltaTime);
 }
}

