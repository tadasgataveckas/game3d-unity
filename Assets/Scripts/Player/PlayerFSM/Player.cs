using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region State variables

    public PlayerStateMachine StateMachine { get; private set; }
    public PlayerIdleState IdleState { get; private set; }
    public PlayerMoveState MoveState { get; private set; }

    public PlayerAttackState AttackState { get; private set; }

    #endregion

    #region Check variables
    [SerializeField]
    private Transform groundCheck;
    [SerializeField]
    private Transform wallCheck;

    #endregion

    #region Player components
    public Animator Animator { get; private set; }
    public PlayerInputHandler InputHandler { get; private set; }
    public Rigidbody PlayerRigidbody { get; private set; }

    public BoxCollider AttackCollider { get; private set; }
    public BoxCollider CollisionCollider { get; private set; }

    [SerializeField]
    private PlayerData PlayerData;

    public Vector3 CurrentVelocity { get; private set; }
    public int PlayerDirection { get; private set; }
    private Vector3 VelocityData;

    public Camera camera { get; private set; }
    #endregion

    #region Unity Callback methods

    public void Awake()
    {

        StateMachine = new PlayerStateMachine();
        IdleState = new PlayerIdleState(this,StateMachine,PlayerData,"idling");
        MoveState = new PlayerMoveState(this, StateMachine, PlayerData, "moving");
        AttackState = new PlayerAttackState(this, StateMachine, PlayerData, "attacking");
        
    }

    private void Start()
    {
        Animator = GetComponent<Animator>();
        InputHandler = GetComponent<PlayerInputHandler>();
        PlayerRigidbody = GetComponent<Rigidbody>();
        CollisionCollider = GetComponent<BoxCollider>();
        AttackCollider = GetComponentInChildren<BoxCollider>();
        camera = GetComponentInChildren<Camera>();


        PlayerDirection = 1;
        StateMachine.Initialize(IdleState);
    }

    private void Update()
    {
        CurrentVelocity = PlayerRigidbody.velocity;
        StateMachine.CurrentState.LogicUpdate();
    }

    private void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate();
    }

    #endregion

    #region Custom methods



    //Z and X velocity
    public void SetVelocity(float velocityx,float velocityz)
    {
        VelocityData.Set(velocityx*Time.deltaTime, 0f, velocityz*Time.deltaTime);
        PlayerRigidbody.velocity = VelocityData;
        CurrentVelocity = VelocityData;
    }


    public void RotateCharacter(Vector3 CharacterDirection)
    {
        float TargetAngle = Mathf.Atan2(CharacterDirection.x, CharacterDirection.z) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, TargetAngle, 0f);
    }

    public Vector3 ReturnMovementVector3(float InputX, float InputZ)
    {
        Matrix4x4 rotationMatrix = Matrix4x4.Rotate(transform.rotation);
        Vector3 inputVector = new Vector3(InputX, 0.0f, InputZ).normalized;
        return rotationMatrix.MultiplyVector(inputVector);
    }
    #endregion

    #region deprecated
    public void EnableAttackCollider()
    {
        AttackCollider.isTrigger = true;
    }

    public void DisableAttackCollider()
    {
        AttackCollider.isTrigger = false;
    }

    public void SetVelocityX(float velocity)
    {
        VelocityData.x = velocity;
        PlayerRigidbody.velocity = VelocityData;
        CurrentVelocity = VelocityData;

    }

    public void SetVelocityZ(float velocity)
    {
        VelocityData.z = velocity;
        PlayerRigidbody.velocity = VelocityData;
        CurrentVelocity = VelocityData;
    }
    public void RotateCharacterFace(float MouseX, float MouseY)
    {

        float TargetAngle = Mathf.Atan2(MouseX, MouseY) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, TargetAngle, 0f);
    }

    public void SetVelocityV(Vector3 movementInput)
    {
        VelocityData.Set(movementInput.x * PlayerData.MovementVelocity, movementInput.y, movementInput.z * PlayerData.MovementVelocity);
        PlayerRigidbody.velocity = VelocityData ;
        CurrentVelocity = VelocityData;
    }
    #endregion
}
