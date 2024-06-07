using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponF : MonoBehaviour
{
    public WeaponStateMachine StateMachine { get; private set; }

    public WeaponIdleState IdleState { get; private set; }

    public WeaponAttackState AttackState { get; private set; } 

    public Animator Animator { get; private set; }

    public WeaponInputHandler InputHandler { get; private set; }

    public BoxCollider WeaponCollider { get; private set; }

    public MeleeWeapon WeaponMelee { get; set; }

    [SerializeField]
    private WeaponData weaponData;



    public void Awake()
    {
        StateMachine = new WeaponStateMachine();
        IdleState = new WeaponIdleState(this, StateMachine, weaponData, "WeaponIdling");
        AttackState = new WeaponAttackState(this, StateMachine, weaponData, "WeaponAttacking");
    }

    public void Start()
    {
        Animator = GetComponent<Animator>();
        InputHandler = GetComponent<WeaponInputHandler>();
        WeaponCollider = GetComponent<BoxCollider>();
        WeaponMelee = GetComponent<MeleeWeapon>();
        StateMachine.Initialize(IdleState);
    }

    public void Update()
    {
        StateMachine.CurrentState.LogicUpdate();
    }
    private void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate();
    }
}
