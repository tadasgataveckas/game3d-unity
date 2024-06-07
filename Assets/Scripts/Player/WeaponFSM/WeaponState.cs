using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class WeaponState : MonoBehaviour 
{
    protected WeaponF weapon;
    protected WeaponStateMachine stateMachine;
    protected WeaponData weaponData;
    private string animationName;
    public bool isExitingState;
    public bool isAttacking;
    public bool isAnimationFinished;
    public bool attackInput;

	private void Start()
	{
       
            
	}
	public WeaponState(WeaponF weapon, WeaponStateMachine stateMachine, WeaponData weaponData, string animationName)
    {
        this.weapon = weapon;
        this.stateMachine = stateMachine;
        this.weaponData = weaponData;
        this.animationName = animationName;
    }

    public virtual void Enter()
    {
        DoChecks();
        
        weapon.Animator.SetBool(animationName, true);
        Debug.Log(animationName);
        isExitingState = false;
        isAnimationFinished = false;
        
    }

    public virtual void Exit()
    {
        weapon.Animator.SetBool(animationName, false);
        
        isExitingState = true;
    }

    public virtual void LogicUpdate()
    {
        attackInput = weapon.InputHandler.AttackInput;
        
        
            if (!attackInput && weapon.WeaponMelee.isAnimationFinished)
            {
                
                stateMachine.ChangeState(weapon.IdleState);
            }
            else if (attackInput)
            {
                stateMachine.ChangeState(weapon.AttackState);
            }
        
        
    }

    public virtual void PhysicsUpdate()
    {
        DoChecks();
    }
    public virtual void DoChecks()
    {

    }

    public virtual void AnimationFinishedTrigger() => isAnimationFinished = true;

    public virtual string GetAnimationName() => animationName;
}
