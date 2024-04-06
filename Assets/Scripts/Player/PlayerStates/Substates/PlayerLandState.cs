using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLandState : PlayerGroundedState
{
    public PlayerLandState(Player player, PlayerStateMachine statemachine, PlayerData playerdata, string animationboolname) : base(player, statemachine, playerdata, animationboolname)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Player.JumpState.ResetJumpCount();
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        if (!isExitingState)
        {
            if (Player.IsGrounded && (Player.InputHandler.NormInputX != 0 || Player.InputHandler.NormInputZ!= 0))
            {
                StateMachine.ChangeState(Player.MoveState);
            }
            else if (Player.IsGrounded && Player.InputHandler.NormInputX == 0  && Player.InputHandler.NormInputZ == 0) 
            {
                StateMachine.ChangeState(Player.IdleState);
            }
        }
    }
}
