using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    private WeaponData weaponData;

    protected Animator weaponAnimator;

    protected virtual void Start()
    {
        weaponAnimator = transform.GetComponent<Animator>();
        gameObject.SetActive(true);
    }
    
}
