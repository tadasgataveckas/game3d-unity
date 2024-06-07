using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerJumpState : PlayerInAirSuperState
{
    private int jumpsLeft;
    private Vector3 movementVector;
    private int InputX;
    private int InputZ;
    public PlayerJumpState(Player player, PlayerStateMachine statemachine, PlayerData playerdata, string animationboolname) 
                            : base(player, statemachine, playerdata, animationboolname)
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
        InputX = Player.InputHandler.NormInputX; InputZ = Player.InputHandler.NormInputZ;
        movementVector = Player.ReturnMovementVector3Y(InputX, Player.InputHandler.JumpInput, InputZ);
        Player.SetVelocityVZXY(movementVector);
        Player.InputHandler.SetJumpInputFalse();
        isAbilityDone = true;
        jumpsLeft--;


    }

    public bool CanJump() => jumpsLeft >= 0 ? true : false;

    public void ResetJumpCount() => jumpsLeft = PlayerData.JumpAmount;

    public void DecreaseJumpCount() => jumpsLeft--;
}
