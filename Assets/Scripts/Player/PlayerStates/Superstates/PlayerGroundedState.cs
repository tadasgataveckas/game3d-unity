using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedState : PlayerState
{
    protected int InputX;
    protected int InputZ;
    private bool JumpInput;
    private bool IsGrounded;
    protected bool attackInput;
    protected Vector3 movementVector;
    public PlayerGroundedState(Player player, PlayerStateMachine statemachine, PlayerData playerdata, string animationboolname) : base(player, statemachine, playerdata, animationboolname)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
        //IsGrounded = Player.CheckGrounded();
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        InputX = Player.InputHandler.NormInputX;
        InputZ = Player.InputHandler.NormInputZ;
        attackInput = Player.InputHandler.AttackInput;
        movementVector.Set(InputX, 0, InputZ);
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
