using System;


public class Player_FallState : Player_InAirState
{
    public Player_FallState(Player player, StateMachine stateMachine, string stateName) : base(player, stateMachine, stateName)
    {
    }

    public override void Update()
    {
        base.Update();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();

        if (player.GroundDetected)
        {
            if (Math.Abs(player.MoveInput.x) > 0.001f) stateMachine.ChangeState(player.MoveState);
            else stateMachine.ChangeState(player.IdleState);
        }

    }
}
