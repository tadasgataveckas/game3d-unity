using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerAirState : PlayerInAirSuperState
{
    
    protected int InputX;
    protected int InputZ;
    private bool JumpInput;
    //protected bool IsGrounded;
    private bool isJumping;
    private bool jumpInputStop;
    protected Vector3 movementVector;
    public PlayerAirState(Player player, PlayerStateMachine statemachine, PlayerData playerdata, string animationboolname) : base(player, statemachine, playerdata, animationboolname)
    {
    }
    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public override void DoChecks()
    {
        base.DoChecks();
        IsGrounded = Player.CheckGrounded();
        //Debug.Log("Grounded AS?: " + IsGrounded);
    }
    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
        Player.JumpState.ResetJumpCount();

    }
    
    public override void LogicUpdate()
    {
        base.LogicUpdate();
        
        InputX = Player.InputHandler.NormInputX;
        InputZ = Player.InputHandler.NormInputZ;
        JumpInput = Player.InputHandler.JumpInput;
        jumpInputStop = Player.InputHandler.JumpInputStop;
        //movementVector.Set(InputX, Player.PlayerRigidbody.velocity.y, InputZ);
        //Debug.Log("isgrounded? " + IsGrounded);
        //CheckJumpInput();
        if (!isExitingState)
        {
            if (IsGrounded)
            {
                StateMachine.ChangeState(Player.LandState);
            }
            else if (IsGrounded && (InputX != 0 || InputZ != 0))
            {
                StateMachine.ChangeState(Player.MoveState);
            }
            //else if (JumpInput && Player.JumpState.CanJump())
            //{
            //    StateMachine.ChangeState(Player.JumpState);
            //}
            else
            {
                movementVector = Player.ReturnMovementVector3(InputX, InputZ);
                Player.SetVelocityAccelerate(movementVector);
            }
        }
    }
   
    private void CheckJumpInput()
    {
        if (isJumping)
        {
            if (jumpInputStop)
            {
                movementVector = Player.ReturnMovementVector3(InputX, InputZ);
                Player.SetVelocityVZXY(movementVector);
                isJumping = false;
            }
            else if (Player.CurrentVelocity.y <= 0)
            {
                isJumping = false;
            }
        }
    }

    public void SetIsJumping() => isJumping = true;


}
