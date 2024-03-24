using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newPlayerData", menuName = "Data/Player Data/Base Data")]
public class PlayerData : ScriptableObject
{
    [Header("Move state variables")]

    public float MovementVelocity = 13.94f;

    [Header("Check variables")]
    public float groundCheckRadius = 0.2f;
    public LayerMask groundMask;
    public float wallCheckDistance = 1f;
}
