using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class EnemyCharacteristics : MonoBehaviour
{
	[SerializeField] protected int MaxHealth;
	[SerializeField] protected int currentHealth;
	[SerializeField] public int ArmorValue;

	private Damageable damageable;

	private void Start()
	{
		damageable = GetComponent<Damageable>();
		currentHealth = MaxHealth;
		if(damageable != null)
		{
			damageable.OnDamaged.AddListener((int damageAmount)
				=> ApplyDamage(damageAmount,ArmorValue));
		}
	}

	public void ApplyDamage(int damageAmount, int armorValue)
	{
		int number = (int)Mathf.Ceil((damageAmount *
			Random.value * 3f) - (armorValue * 0.2f));
		if (number > 0)
			currentHealth -= (int)Mathf.Ceil((damageAmount * 
				Random.value * 3f) - (armorValue * 0.2f));
		
		Debug.Log((int)Mathf.Ceil(damageAmount * Random.value *
			Random.value * 3f) - (armorValue * 0.2f) + "Damage");
		Debug.Log("Enemy took damage. Current health: " + currentHealth);


		if (currentHealth <= 0)
		{
			Die();
		}
	}

	void Die()
	{
		Debug.Log("Enemy died.");
		Destroy(gameObject);
	}
}
