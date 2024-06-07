using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "newWeaponData", menuName = "Data/Weapon Data/Base weapon data", order = 0)]
public class WeaponData : ScriptableObject
{

    [SerializeField] public string weaponName;
    [SerializeField] public float attackDamage;
    [SerializeField] public float attackRate;
}
