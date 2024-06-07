using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    Player player { get; set; }
    public Vector3 RawMovementInput {  get; private set; }
    public int NormInputX { get; private set; }
    public int NormInputZ { get; private set; }
    public int NormInputY { get; private set; }//up axis

    
    public bool JumpInput { get; private set; }
    public bool JumpInputStop { get; private set; } 

    public bool AttackInput { get; private set; }

    public float mousePositionX { get; private set; }
    public float mousePositionY { get; private set; }

    public Vector2 mousePositionXY { get; private set; }
    [SerializeField]
    private float inputHoldTime = 0.1f;

    private float jumpInputStartTime;

    private void Update()
    {
        CheckInputHoldTime();
    }

    #region Movement on Z and X axis
    public void OnMoveInputZ(InputAction.CallbackContext context)
    {
        RawMovementInput = context.ReadValue<Vector3>();
        NormInputZ = (int)RawMovementInput.z;
    }

    public void OnMoveInputX(InputAction.CallbackContext context)
    {
        RawMovementInput = context.ReadValue<Vector3>();
        NormInputX = (int)RawMovementInput.x;
    }

    #endregion

    #region Jump logic
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
        }
        if (context.canceled)
        {
            JumpInputStop = true;
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

    #endregion

    #region Mouse logic
    public void OnMouseMoveX(InputAction.CallbackContext context)
    {
        mousePositionX = context.ReadValue<float>();
    }

    public void OnMouseMoveY(InputAction.CallbackContext context)
    {   
        mousePositionY = context.ReadValue<float>();
    }

    public void OnMouseMoveXY(InputAction.CallbackContext context)
    {
        mousePositionXY = context.ReadValue<Vector2>();
    }
    #endregion
}
