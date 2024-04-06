using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInAirSuperState : PlayerState
{
    protected bool isAbilityDone;

    protected bool IsGrounded;
    public PlayerInAirSuperState(Player player, PlayerStateMachine statemachine, PlayerData playerdata, string animationboolname) : base(player, statemachine, playerdata, animationboolname)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
        IsGrounded = Player.CheckGrounded();
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
        //if (isAbilityDone)
        //{
            //if (!IsGrounded)
            //{
            //    StateMachine.ChangeState(Player.AirState);
            //}
            //else
            if (IsGrounded && (Player.InputHandler.NormInputX ==0 && Player.InputHandler.NormInputZ ==0))
            {
                StateMachine.ChangeState(Player.IdleState);
            }
            else if (IsGrounded && (Player.InputHandler.NormInputZ !=0|| Player.InputHandler.NormInputX != 0))
            {
                StateMachine.ChangeState(Player.MoveState);
            }

        //}
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
