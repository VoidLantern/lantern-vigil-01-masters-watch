using UnityEngine;

public class Player_GroundedState : EntityState
{
    public Player_GroundedState(Player player, StateMachine stateMachine, string stateName) : base(player, stateMachine, stateName)
    {
    }

    public override void Update()
    {
        base.Update();

        // if (playerInputs.Player.Jump.WasPerformedThisFrame())
        //     stateMachine.ChangeState(player.JumpState);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        if (player.jumpBufferCounter > 0 && player.coyoteCounter > 0)
        {
            player.jumpBufferCounter = 0f;
            stateMachine.ChangeState(player.JumpState);
        }
    }

}
