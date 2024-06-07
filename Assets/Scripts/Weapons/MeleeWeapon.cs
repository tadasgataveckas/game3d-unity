using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MeleeWeapon : Weapon
{
    [SerializeField]
    protected MeleeWeaponData weaponData;
    private List<Damageable> detectedDamage = new List<Damageable>();
    public bool isAnimationFinished;


	public void AnimationActionTrigger()
    {
        CheckMeleeAttack();
    }

    private void CheckMeleeAttack()
    {
        
        if(detectedDamage.Count > 0)
        foreach (Damageable item in detectedDamage)
        {
            item.ApplyDamage(
                (int)weaponData.attackDamage);
        }
    }

    public void AddToDetectedList(Collider collision)
    {

        Damageable damageable = collision.GetComponentInParent<Damageable>();

        if (damageable != null && !detectedDamage.Contains(damageable))
        {
            detectedDamage.Add(damageable);
        }
    }

    public void RemoveFromDetected(Collider collision)
    {

		Damageable damageable = collision.GetComponent<Damageable   >();
		if (damageable != null && detectedDamage.Contains(damageable))
        {
            detectedDamage.Remove(damageable);
        }
    }

	private void OnTriggerEnter(Collider other)
	{
		//Debug.Log($"OnTriggerEnter detected: {other.name}");
		AddToDetectedList(other);
	}

	private void OnTriggerExit(Collider other)
	{
		//Debug.Log($"OnTriggerExit: {other.name}");
		RemoveFromDetected(other);
	}
	public virtual void AnimationFinishedTriggerTrue()
        => isAnimationFinished = true;

	public virtual void AnimationFinishedTriggerFalse() 
        => isAnimationFinished = false;

}
