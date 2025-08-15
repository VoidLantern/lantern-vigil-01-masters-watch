using UnityEngine;

public abstract class EntityState
{
    protected Player player;
    protected StateMachine stateMachine;
    protected int animBoolHash;
    protected string stateName;
    protected Rigidbody2D rb;
    protected Animator anim;
    public EntityState(Player player, StateMachine stateMachine, string stateName)
    {
        this.player = player;
        this.stateMachine = stateMachine;
        this.stateName = stateName;
        rb = player.Rb;
        anim = player.Anim;
        animBoolHash = Animator.StringToHash(stateName);
    }

    public virtual void Enter()
    {
        anim.SetBool(animBoolHash, true);
    }
    public virtual void Update() { }
    public virtual void Exit()
    {
        anim.SetBool(animBoolHash, false);
    }

    public virtual void PhysicsUpdate() { }

}
