using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class WeaponInputHandler : MonoBehaviour
{
    WeaponF weapon { get; set; }

    public bool AttackInput { get; private set; }

    public void OnAttackInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Debug.Log("attack input");
            AttackInput = true;
        }
        if (context.performed)
        {
            Debug.Log("attack input held");
            AttackInput = true;
        }
        if (context.canceled)
        {
            Debug.Log("attack input released");
            AttackInput = false;
        }
    }

}
