using System;
using DG.Tweening;
using UnityEngine;

namespace Enemy
{
    public class EnemyMovement : BaseMovementController
    {
        private Transform _leftWall;
        private Transform _rightWall;
        private bool _isAlive;

        private void Start()
        {
            _isAlive = GetComponent<Platformer.Enemy>().isAlive;
            FindWalls();
            gameObject.transform.position = _leftWall.position + (_rightWall.position - _leftWall.position) / 2;
            Movement();
        }


        protected override void Movement()
        {
            var sequence = DOTween.Sequence();
            float time = Vector3.Distance(_leftWall.position, _rightWall.position) / speed;
            bool isLeft = false;

            sequence.AppendCallback(() => isLeft = false);
            sequence.AppendCallback(() => _animationController.SetWalkDirection(isLeft));
            sequence.Append(transform.DOMove(_rightWall.position, time).SetEase(Ease.Linear));
            sequence.AppendCallback(() => isLeft = true);
            sequence.AppendCallback(() => _animationController.SetWalkDirection(isLeft));
            sequence.Append(transform.DOMove(_leftWall.position, time).SetEase(Ease.Linear));
            if (_isAlive)
            {
                sequence.OnComplete(() => Movement());
            }
        }


        private void FindWalls()
        {
            //сюда запишется инфо о пересечении луча, если оно будет
            RaycastHit2D hit;
            hit = Physics2D.Raycast(transform.position, Vector2.left);
            //если луч с чем-то пересёкся, то..
            if (hit.collider != null)
            {
                _leftWall = hit.transform;
            }
            else
            {
                throw new Exception("Вокруг врага нет стены");
            }

            hit = Physics2D.Raycast(transform.position, Vector2.right);
            if (hit.collider == null)
            {
                throw new Exception("Вокруг врага нет стены");
            }
            else
            {
                _rightWall = hit.transform;
            }
        }
    }
}