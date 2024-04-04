using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newPlayerData", menuName = "Data/Player Data/Base Data")]
public class PlayerData : ScriptableObject
{
    [Header("Move state variables")]
    public float Acceleration = 10.2f;
    public float MovementVelocity = 13.94f;

    [Header("Check variables")]
    public Vector3 groundCheckRadius = new Vector3(1f, 0.2f, 1f);
    public LayerMask groundMask;
    //[SerializeField] Transform groundCheckObject;
    //public float wallCheckDistance = 1f;

    [Header("Airstate variables")]
    public float JumpVelocity = 20f;
    public int JumpAmount = 1;
    public float variableJumpHeightMultiplier = 2f;
}
