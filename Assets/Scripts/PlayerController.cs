using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public event Action OnWin;
    public event Action OnDead;
    public event Action OnCoinCollected;
}