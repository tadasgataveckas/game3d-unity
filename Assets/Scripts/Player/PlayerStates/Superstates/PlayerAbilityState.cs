using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAbilityState : PlayerState
{
    protected bool attackInput;
    public PlayerAbilityState(Player player, PlayerStateMachine statemachine, PlayerData playerdata, string animationboolname) : base(player, statemachine, playerdata, animationboolname)
    {
    }

    public override void LogicUpdate()
    {
        base.LogicUpdate();
        attackInput = Player.InputHandler.AttackInput;
    }
}
