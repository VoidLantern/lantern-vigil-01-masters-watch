using System;
using UnityEngine;

public class Player_WallSlideState : EntityState
{
    public Player_WallSlideState(Player player, StateMachine stateMachine, string stateName) : base(player, stateMachine, stateName)
    {
    }


    public override void Update()
    {
        base.Update();

        // player.SetVelocity()
        if (playerInputs.Player.Jump.WasPerformedThisFrame())
        {
            stateMachine.ChangeState(player.WallJumpState);
        }

        if (player.WallDetected == false)
            stateMachine.ChangeState(player.FallState);

        if (player.GroundDetected)
        {
            stateMachine.ChangeState(player.IdleState);
            // player.Flip();
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        HandleWallSlide();

        if (player.jumpBufferCounter > 0)
        {
            player.jumpBufferCounter = 0;
            stateMachine.ChangeState(player.WallJumpState);
            return;
        }
    }

    void HandleWallSlide()
    {
        if (player.MoveInput.y < 0) player.SetVelocity(rb.linearVelocity.x, player.MoveInput.y);
        else player.SetVelocity(player.MoveInput.x, rb.linearVelocity.y * player.wallSlideSlowMultiplier);
    }
}
