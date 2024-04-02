using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerGroundedState
{
    
    public PlayerIdleState(Player player, PlayerStateMachine statemachine, PlayerData playerdata, string animationboolname) : base(player, statemachine, playerdata, animationboolname)
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
        Player.EnableAttackCollider();
        Vector3 mousePosition = Player.camera.ScreenToWorldPoint(
            new Vector3(Player.InputHandler.mousePositionXY.x, 0.0f, Player.InputHandler.mousePositionXY.y));
        Player.RotateCharacter(mousePosition);
        if(InputX !=0 || InputZ !=0 || (InputX !=0 && InputZ!=0))
        {
            StateMachine.ChangeState(Player.MoveState);
        }
        if (attackInput)
        {
            StateMachine.ChangeState(Player.AttackState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
