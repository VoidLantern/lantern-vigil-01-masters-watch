using System;
using UnityEngine;

public class Player_IdleState : Player_GroundedState
{
    public Player_IdleState(Player player, StateMachine stateMachine, string stateName) : base(player, stateMachine, stateName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.SetVelocity(0, rb.linearVelocity.y);
    }

    public override void Update()
    {
        base.Update();

        if (player.MoveInput.x == player.facingDirection && player.WallDetected) return;

        if (rb.linearVelocity.y < 0)
            stateMachine.ChangeState(player.FallState);


        if (Math.Abs(player.MoveInput.x) > 0.001f)
        {
            stateMachine.ChangeState(player.MoveState);
        }
    }
}
