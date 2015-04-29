using UnityEngine;
using System.Collections;
using System;

public class MagicalCombat : MonoBehaviour {
	public AudioClip fireSound;
	public GameObject projectileObj;
	public Transform launchPoint;

	private Stats stats;
	private AudioSource fireSource;
	
	void Awake (){
		stats = gameObject.GetComponent<Stats>();
		fireSource = this.GetComponent<AudioSource>();
	}
	
	public void Fight(GameObject target){
		this.Attack(target); 
	}

	public void DoDamage (GameObject target){
		if (this.stats.willpower > target.GetComponent<Stats>().resilience)
		{
			int damage = (this.stats.willpower - target.GetComponent<Stats>().resilience);
			target.GetComponent<Stats>().TakeDamage(damage); 
		}
		
		else target.GetComponent<Stats>().TakeDamage(1);
	}
	
	private void Attack(GameObject target){
		GameObject projectile = Instantiate(projectileObj, launchPoint.position, Quaternion.identity) as GameObject;

		projectile.GetComponent<FireTowardsTarget>().target = target;
		projectile.GetComponent<FireTowardsTarget>().caster = gameObject;

		fireSource.PlayOneShot(fireSound);
	}
}

