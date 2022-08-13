using System;
using UnityEngine;

namespace Player
{
    public class Player : MonoBehaviour
    {
        public event Action OnWin;
        public event Action OnDead;
        public event Action<int> OnCoinCollected;
    }
    
    
    

}