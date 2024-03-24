using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    public Vector3 RawMovementInput {  get; private set; }
    public int NormInputX { get; private set; }
    public int NormInputZ { get; private set; }
    public int NormInputY { get; private set; }//up axis

    public bool JumpInput { get; private set; }
    public bool JumpInputStop { get; private set; }

    public bool AttackInput { get; private set; }

    [SerializeField]
    private float inputHoldTime = 0.1f;

    private float jumpInputStartTime;

    private void Update()
    {
        CheckInputHoldTime();
    }

    public void OnMoveInput(InputAction.CallbackContext context)
    {
        RawMovementInput = context.ReadValue<Vector3>();
        NormInputX = (int)(RawMovementInput.x);
        NormInputY = (int)RawMovementInput.y;
        NormInputZ = (int)RawMovementInput.z;

        Debug.Log(NormInputX + " " + NormInputZ);
    }

    public void OnJumpInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            JumpInput = true;
            jumpInputStartTime = Time.time;
            JumpInputStop = false;

        }
        if (context.performed)
        {
            // Debug.Log("Jump called(held down)");
        }
        if (context.canceled)
        {
            JumpInputStop = true;
        }
    }

    public void OnAttackInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            AttackInput = true;
        }
        if (context.canceled)
        {
            AttackInput = false;
        }
    }
    public void SetJumpInputFalse() => JumpInput = false;

    private void CheckInputHoldTime()
    {
        if (Time.time >= jumpInputStartTime + inputHoldTime)
        {
            JumpInput = false;
        }
    }

}
