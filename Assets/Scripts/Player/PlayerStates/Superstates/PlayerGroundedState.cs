using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGroundedState : PlayerState
{
    protected int InputX;
    protected int InputZ;
    private bool JumpInput;
    protected bool IsGrounded;
    protected bool attackInput;
    protected Vector3 movementVector;
    public PlayerGroundedState(Player player, PlayerStateMachine statemachine, PlayerData playerdata, string animationboolname) : base(player, statemachine, playerdata, animationboolname)
    {
    }

    public override void DoChecks()
    {
        base.DoChecks();
        IsGrounded = Player.CheckGrounded();
        //Debug.Log("Grounded GS?: " + IsGrounded);
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
        JumpInput = Player.InputHandler.JumpInput;
        movementVector.Set(InputX, Player.CurrentVelocity.y, InputZ);
        if (JumpInput && IsGrounded)
        {
            PerformJump(2f);
            StateMachine.ChangeState(Player.AirState);
        }
        else if (!IsGrounded)
        {
            StateMachine.ChangeState(Player.AirState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

    public void PerformJump(float jumpHeight)
    {
        // Calculate the initial velocity needed for a given jump height
        float jumpVelocity = Mathf.Sqrt(2 * Mathf.Abs(Physics.gravity.y) * jumpHeight);

        // Set the Rigidbody's velocity for the jump
        Player.PlayerRigidbody.velocity = new Vector3(Player.PlayerRigidbody.velocity.x, jumpVelocity, Player.PlayerRigidbody.velocity.z);
    }
}
