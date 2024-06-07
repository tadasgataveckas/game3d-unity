using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAttackState : WeaponState
{
    public WeaponAttackState(WeaponF weapon, WeaponStateMachine stateMachine, WeaponData weaponData, string animationName)
        : base(weapon, stateMachine, weaponData, animationName)
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
        

        
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

	public override void AnimationFinishedTrigger()
	{
		base.AnimationFinishedTrigger();
	}
}
