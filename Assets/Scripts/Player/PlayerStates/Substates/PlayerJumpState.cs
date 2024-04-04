using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerJumpState : PlayerAirState
{
    private int jumpsLeft;
    public PlayerJumpState(Player player, PlayerStateMachine statemachine, PlayerData playerdata, string animationboolname) : base(player, statemachine, playerdata, animationboolname)
    {
        jumpsLeft = PlayerData.JumpAmount;
    }

    public override void DoChecks()
    {
        base.DoChecks();
    }

    public override void Enter()
    {
        base.Enter();
        IsGrounded = Player.CheckGrounded();
    }

    public override void Exit()
    {
        base.Exit();
    }
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        
        movementVector = Player.ReturnMovementVector3Y(InputX, Player.InputHandler.JumpInput, InputZ);
        //Debug.Log(movementVector);
        Player.SetVelocityVZXY(movementVector);
        Player.InputHandler.SetJumpInputFalse();
        isAbilityDone = true;
        jumpsLeft--;
        Player.AirState.SetIsJumping();
        //if (!isExitingState)
        //{
        //    if (IsGrounded && (InputX == 0 && InputZ == 0))
        //    {
        //        StateMachine.ChangeState(Player.IdleState);
        //    }
        //    else if (IsGrounded && (InputX != 0 || InputZ != 0))
        //    {
        //        StateMachine.ChangeState(Player.MoveState);
        //    }
        //}

    }

    public bool CanJump() => jumpsLeft >= 0 ? true : false;

    public void ResetJumpCount() => jumpsLeft = PlayerData.JumpAmount;

    public void DecreaseJumpCount() => jumpsLeft--;
}
