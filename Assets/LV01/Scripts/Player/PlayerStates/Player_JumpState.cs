using UnityEngine;

public class Player_JumpState : Player_InAirState
{
    public Player_JumpState(Player player, StateMachine stateMachine, string stateName) : base(player, stateMachine, stateName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.SetVelocity(rb.linearVelocity.x, 0);
        player.SetVelocity(rb.linearVelocity.x, player.jumpForce);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        if (rb.linearVelocity.y < 0)
            stateMachine.ChangeState(player.FallState);
    }


}
