using Unity.VisualScripting;
using UnityEngine;

public class Player_BasicAttackState : EntityState
{
    public Player_BasicAttackState(Player player, StateMachine stateMachine, string stateName) : base(player, stateMachine, stateName)
    {
    }

    private float attackVelocityTimer;

    public override void Enter()
    {
        base.Enter();
        player.swordCollider.SetActive(true);
        ApplyAttackVelocity();
    }

    public override void Update()
    {
        base.Update();

        HandleAttackVelocity();

        if (triggerCalled)
            stateMachine.ChangeState(player.IdleState);
    }

    public override void Exit()
    {
        base.Exit();
        player.swordCollider.SetActive(false);
    }

    void ApplyAttackVelocity()
    {
        attackVelocityTimer = player.attackVelocityDuration;
        player.SetVelocity(player.attackVelocity.x * player.facingDirection, player.attackVelocity.y);
    }

    void HandleAttackVelocity()
    {
        attackVelocityTimer -= Time.deltaTime;
        if (attackVelocityTimer < 0f)
            player.SetVelocity(0, rb.linearVelocity.y);
    }



}
