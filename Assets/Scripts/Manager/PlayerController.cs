using System;
using UnityEngine;

namespace Manager
{
    public class PlayerController : MonoBehaviour
    {
        public event Action OnWin;
        public event Action OnDead;
        public event Action OnCoinCollected;
    }
}