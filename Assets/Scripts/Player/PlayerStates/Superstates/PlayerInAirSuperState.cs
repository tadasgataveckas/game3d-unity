using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInAirSuperState : PlayerState
{
    protected bool isAbilityDone;

    private bool isGrounded;
    public PlayerInAirSuperState(Player player, PlayerStateMachine statemachine, PlayerData playerdata, string animationboolname) : base(player, statemachine, playerdata, animationboolname)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
        isGrounded = Player.CheckGrounded();
    }

    public override void Enter()
    {
        base.Enter();
        isAbilityDone = false;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (isAbilityDone)
        {
           if (!isGrounded)
            {
                StateMachine.ChangeState(Player.AirState);
            }
            else if (isGrounded && Player.CurrentVelocity.x < 0.001f && Player.CurrentVelocity.z < 0.001f)
            {
                StateMachine.ChangeState(Player.IdleState);
            }
            else if (isGrounded && (Player.CurrentVelocity.x > 0f || Player.CurrentVelocity.z > 0f))
            {
                StateMachine.ChangeState(Player.MoveState);
            }

        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
