using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public StateMachine StateMachine { get; private set; }
    public PlayerInputs PlayerInputs { get; private set; }
    public Player_IdleState IdleState { get; private set; }
    public Player_MoveState MoveState { get; private set; }
    [Header("Player Components")]
    public Rigidbody2D Rb { get; private set; }
    public Animator Anim { get; private set; }
    [Header("Movement Details")]
    public Vector2 MoveInput { get; private set; }
    public float moveSpeed;
    private bool facingRight = true;
    public int facingDirection = 1;

    void Awake()
    {
        Rb = GetComponent<Rigidbody2D>();
        Anim = GetComponentInChildren<Animator>();
        StateMachine = new StateMachine();
        PlayerInputs = new PlayerInputs();
        IdleState = new Player_IdleState(this, StateMachine, "idle");
        MoveState = new Player_MoveState(this, StateMachine, "move");
    }
    void OnEnable()
    {
        PlayerInputs.Enable();

        PlayerInputs.Player.Movement.performed += ctx => MoveInput = ctx.ReadValue<Vector2>();
        PlayerInputs.Player.Movement.canceled += ctx => MoveInput = Vector2.zero;
    }
    void OnDisable()
    {
        PlayerInputs.Disable();
    }
    void Start()
    {
        StateMachine.InitializeState(IdleState);
    }


    void Update()
    {
        StateMachine.UpdateActiveState();
    }


    public void SetVelocity(float xVelocity, float yVelocity)
    {
        Rb.linearVelocity = new Vector2(xVelocity, yVelocity);
        HandleFlip(xVelocity);
    }

    void HandleFlip(float xVelocity)
    {
        if (xVelocity < 0 && facingRight) Flip();
        else if (xVelocity > 0 && facingRight == false) Flip();
    }

    public void Flip()
    {
        transform.Rotate(0, 180, 0);
        facingRight = !facingRight;
        facingDirection *= -1;
    }
}
