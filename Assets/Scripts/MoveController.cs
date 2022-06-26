using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    private Animator anim;
    private SpriteRenderer sprite;
    private Rigidbody2D rb;
    private bool isGrounded = true;
    private bool isDied = false;
    [SerializeField]private float speed;
    [SerializeField]private float jumpForce;

    public bool IsDied
    {
        get => isDied;
        set => isDied = value;
    }
    private void Awake()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        CheckGround();
    }
    
    private void Update()
    {
        if (isDied)
        {
            State = States.Died;
            return;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            isDied = true;
        }
        if (isGrounded) State = States.Idle;
        if (Input.GetButton("Horizontal")) Run();
        if (isGrounded && Input.GetButton("Jump")) Jump();
    }

    private States State
    {
        get => (States)anim.GetInteger("State");
        set => anim.SetInteger("State", (int)value);
    }

    private void Run()
    {
        if (isGrounded) State = States.Run;
        Vector3 dir = transform.right * Input.GetAxis("Horizontal");
        var position = transform.position;
        position = Vector3.MoveTowards(position, position + dir, speed * Time.deltaTime);
        transform.position = position;
        sprite.flipX = dir.x < 0.0f;
    }
    
    private void Jump()
    {
        rb.AddForce(transform.up * jumpForce, ForceMode2D.Impulse);
    }
    
    private void CheckGround()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(transform.position, 0.7f);
        isGrounded = collider.Length > 1;

        if (!isGrounded) State = States.Jump;
    }

    private enum States
    {
        Idle,
        Run,
        Jump,
        Died,
    }
}
