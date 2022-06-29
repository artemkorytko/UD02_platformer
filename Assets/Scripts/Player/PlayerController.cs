using System;
using System.Collections;
using System.Collections.Generic;
using DefaultNamespace;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerMovement _movement;
    private Health _health;
    
    public event Action OnWin;
    public event Action OnDeath;
    public event Action OnCoinCollected;

    private void Start()
    {
        _movement = GetComponent<PlayerMovement>();
        _health = GetComponent<Health>();
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        //дописать 
    }
    
    //дописать
}