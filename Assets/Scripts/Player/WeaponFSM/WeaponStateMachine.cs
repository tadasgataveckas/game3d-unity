using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponStateMachine
{
    public WeaponState CurrentState { get; private set; }

    public void Initialize(WeaponState startingState)
    {
        CurrentState = startingState;
        CurrentState.Enter();

    }

    public void ChangeState(WeaponState newState)
    {
        CurrentState.Exit();
        CurrentState = newState;
        CurrentState.Enter();
    }
}
