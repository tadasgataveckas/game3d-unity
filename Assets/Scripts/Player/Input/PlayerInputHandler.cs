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
    public bool JumpInputStop { get; private set; } //butinas?

    public bool AttackInput { get; private set; }

    public float mousePositionX { get; private set; }
    public float mousePositionY { get; private set; }

    public Vector2 mousePositionXY { get; private set; }
    //public Vector3 mouseWorldPosition { get; private set; }

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
        
        //Debug.Log("Z input:" + NormInputZ);
        
    }

    public void OnMoveInputX(InputAction.CallbackContext context)
    {
        RawMovementInput = context.ReadValue<Vector3>();
        NormInputX = (int)RawMovementInput.x;

        //Debug.Log("X input:" + NormInputX);

    }

    #endregion

    #region Jump logic
    public void OnJumpInput(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            JumpInput = true;
            //Debug.Log("Jump Input?: " + JumpInput);
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
        //Debug.Log("X axis mouse: " + mousePositionX);
    }

    public void OnMouseMoveY(InputAction.CallbackContext context)
    {   
        mousePositionY = context.ReadValue<float>();
        //Debug.Log("Y axis mouse: " + mousePositionY);
    }

    public void OnMouseMoveXY(InputAction.CallbackContext context)
    {
        mousePositionXY = context.ReadValue<Vector2>();
        
        //Debug.Log("XY axis mouse: " + mousePositionXY.x + ":" + mousePositionXY.y);
    }
    #endregion


    //delete later
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


}
