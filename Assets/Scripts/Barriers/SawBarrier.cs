using System;
using DefaultNamespace;
using Interfaces;
using UnityEngine;
using DG.Tweening;

namespace Barriers
{
    public class SawBarrier : MonoBehaviour, IRevolve
    {
        private Transform transform;

        private void Update()
        {
            Rotation();
        }

        private void OnCollisionEnter2D(Collision2D col)
        {
            if (col.gameObject.TryGetComponent(out PlayerController playerController))
            {
                Debug.Log("DodamagetoPlayer");
            }
        }

        public void Rotation()
        {
            transform.DORotate(new Vector3(0f, 0f, 360f), 0f, RotateMode.WorldAxisAdd);
        }
    }
}