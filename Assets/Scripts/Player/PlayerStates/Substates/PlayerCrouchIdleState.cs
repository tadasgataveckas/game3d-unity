using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrouchIdleState : PlayerGroundedState
{
    public PlayerCrouchIdleState(Player player, PlayerStateMachine statemachine, PlayerData playerdata, string animationboolname) 
        : base(player, statemachine, playerdata, animationboolname)
    {
    }
}
