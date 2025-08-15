using System;
using UnityEngine;

public class Player_MoveState : Player_GroundedState
{
    public Player_MoveState(Player player, StateMachine stateMachine, string stateName) : base(player, stateMachine, stateName)
    {
    }


    public override void Update()
    {
        base.Update();

        if (Math.Abs(player.MoveInput.x) < 0.001f)
        {
            stateMachine.ChangeState(player.IdleState);
        }

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        float x = player.MoveInput.x * player.moveSpeed;
        player.SetVelocity(x, rb.linearVelocity.y);
    }
}
