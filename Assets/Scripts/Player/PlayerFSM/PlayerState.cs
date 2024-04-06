using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class PlayerState
{
    protected Player Player;
    protected PlayerStateMachine StateMachine;
    protected PlayerData PlayerData;
    protected bool isAnimationFinished;
    protected float StartTime;
    public bool isExitingState;
    private string AnimationBoolName;
    public bool IsGrounded;

    public PlayerState(Player player, PlayerStateMachine statemachine, PlayerData playerdata, string animationboolname)
    {
        Player = player;
        StateMachine = statemachine;
        PlayerData = playerdata;
        AnimationBoolName = animationboolname;
    }
    #region Methods
    //virtual = gali buti perrasyta paveldimu klasiu
    public virtual void Enter()
    {
        DoChecks();
        Player.Animator.SetBool(AnimationBoolName, true);
        StartTime = Time.time;
        //statename = StateMachine.CurrentState.statename;
        UnityEngine.Debug.Log(AnimationBoolName);
        isAnimationFinished = false;
        isExitingState = false;
    }

    public virtual void Exit()
    {
        Player.Animator.SetBool(AnimationBoolName, false);
        isExitingState = true;
    }

    public virtual void LogicUpdate()
    {
        IsGrounded = Player.IsGrounded;
    }

    public virtual void PhysicsUpdate()
    {
        DoChecks();
    }

    public virtual void DoChecks()
    {

    }

    public virtual void AnimationTrigger()
    {

    }

    public virtual void AnimationFinishedTrigger()
    => isAnimationFinished = true;
    
    public virtual string GetAnimationName()
    {
        return AnimationBoolName;
    }


    #endregion
}
