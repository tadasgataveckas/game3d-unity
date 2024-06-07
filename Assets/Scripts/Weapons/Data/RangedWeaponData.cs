using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newRangedWeaponData", menuName = "Data/Weapon Data/Ranged weapon data", order = 2)]
public class RangedWeaponData : WeaponData
{
    [SerializeField] public LayerMask HitMask;
    [SerializeField] public Vector3 BulletSpread;
}
