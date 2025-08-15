using UnityEngine;

public class StateMachine
{
    public EntityState CurrentState { get; private set; }

    public void InitializeState(EntityState startState)
    {
        if (startState == null) return;
        CurrentState = startState;
        CurrentState.Enter();
    }

    public void ChangeState(EntityState newState)
    {
        if (newState == null || CurrentState == newState) return;
        CurrentState?.Exit();
        CurrentState = newState;
        CurrentState?.Enter();
    }

    public void UpdateActiveState()
    {
        CurrentState.Update();
    }

    public void PhysicsUpdateActiveState()
    {
        CurrentState?.PhysicsUpdate();
    }
}
