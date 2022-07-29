using Interfaces;
using UnityEngine;
using DG.Tweening;

namespace Barriers
{
    public class SawBarrier : MonoBehaviour, IRevolve
    {
        private Sequence sequence;

        private void Update()
        {
            Rotation();
        }

        private void Start()
        {
            sequence = DOTween.Sequence();
        }

        public void Rotation()
        {
            sequence?.Append(transform.DORotate(new Vector3(0f, 0f, 360f), 2f, RotateMode.WorldAxisAdd));
        }
    }
}