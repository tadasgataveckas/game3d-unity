using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerGroundedState
{
    private Vector3 movementVector;
    private Vector3 mousePosition;
    public PlayerMoveState(Player player, PlayerStateMachine statemachine, PlayerData playerdata, string animationboolname)
        : base(player, statemachine, playerdata, animationboolname)
    {
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

    public override void LogicUpdate()
    {
        base.LogicUpdate();

        movementVector = Player.ReturnMovementVector3(InputX,InputZ);

        Player.SetVelocityAccelerate(movementVector);
        if (!isExitingState)
        {
            if (InputX == 0 && InputZ == 0)
            {
                StateMachine.ChangeState(Player.IdleState);
            }
        }

    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

}
