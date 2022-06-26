using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyMoveController : MonoBehaviour
{
    private Animator anim;
    private SpriteRenderer sprite;
    private Vector3 dir;
    [SerializeField]private float speed;
    private bool run = true;
    private void Awake()
    {
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        dir = transform.right;
    }

    private void Update()
    {
        if (!run) State = States.Idle;
        if (run) Run();
    }
    
    private void Run()
    {
        State = States.Run;
        Collider2D[] collider = Physics2D.OverlapCircleAll((transform.position + transform.up * -0.5f + transform.right * (dir.x * 0.7f)), 0.1f );
        if (collider.Length == 0) dir *= -1f;
        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, Time.deltaTime * speed);
        sprite.flipX = -dir.x < 0.0f;
    }
    
    private States State
    {
        get => (States)anim.GetInteger("State");
        set => anim.SetInteger("State", (int)value);
    }
    
    private enum States
    {
        Idle,
        Run,
        Died,
    }
}
