using UnityEngine;
using DG.Tweening;
using TMPro;
using Unity.VisualScripting;
using Sequence = DG.Tweening.Sequence;

namespace Platformer
{
    public class EnemyMovement : BaseMovementController
    {
        [SerializeField] private Transform leftWall;
        [SerializeField] private Transform rightWall;
        private bool _isAlive;
        
        private void Start()
        {
            _isAlive = GetComponent<Enemy>().isAlive;
            gameObject.transform.position = leftWall.position;
            Movement();
        }
        

        protected override void Movement()
        {
             var sequence = DOTween.Sequence();
             float time = Vector3.Distance(leftWall.position, rightWall.position) / speed;
             bool isLeft;
        
             isLeft = false;
             _animationController.SetWalkDirection(isLeft);
             sequence.Append(transform.DOMove(rightWall.position, time).SetEase(Ease.Linear));
             isLeft = true;
             _animationController.SetWalkDirection(isLeft);
             sequence.Append(transform.DOMove(leftWall.position, time).SetEase(Ease.Linear));
             if (_isAlive)
             {
                 sequence.OnComplete(() => Movement());
             }
        }
    }
}