using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // [SerializeField] private ;
    public event Action OnWin;
    public event Action OnDead;
    public event Action OnCoinCollected;
}
