using UnityEngine;
using System.Collections;
using System;

public class WizardFight : MonoBehaviour {
	public AudioClip attackSound;
	
	private Stats stats;
	
	void Awake (){
		stats = gameObject.GetComponent<Stats>();
	}
	
	public void Fight(GameObject target){
		Stats enemyStats = target.GetComponent<Stats>();
		
		this.Attack(target); 
		Debug.Log (target.name + " health: " + enemyStats.health);
		
		if(this.stats.health <= 0){ 
			Debug.Log (gameObject.name + " falls!");
			Destroy(gameObject);
		}
		
		if(enemyStats.health <= 0){
			Debug.Log (gameObject.name + " killed " + target.name);
			Destroy (target);
		}
	}
	
	private void Attack(GameObject target){
		gameObject.GetComponent<FireProjectile>().Fire(target);
		//this.DoDamage(target);
	}
	
	/*private bool AttackHit(GameObject target){
		return UnityEngine.Random.Range (0, 100) + (this.stats.dexterity * 2) >= (target.GetComponent<Stats>().speed);
	}*/
	
	private void DoDamage (GameObject target){
		if (this.stats.willpower > target.GetComponent<Stats>().resilience)
		{
			int damage = (this.stats.willpower - target.GetComponent<Stats>().resilience);
			
			/*if (this.IsCrit(target)) {
				Debug.Log (gameObject.name + " crits!");
				target.GetComponent<Stats>().TakeDamage(damage * (this.stats.dexterity /10));
			} else */

			target.GetComponent<Stats>().TakeDamage(damage); 
		}
		
		else target.GetComponent<Stats>().TakeDamage(1);
	}
	
	/*private bool IsCrit(GameObject target){
		return ((this.stats.dexterity / 2) + UnityEngine.Random.Range (0, 100) > target.GetComponent<Stats>().dexterity * 2);
	}*/
	
	
}

