using UnityEngine;
using System.Collections;
using System;

public class MagicalCombat : MonoBehaviour {
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
	
	private void DoDamage (GameObject target){
		if (this.stats.willpower > target.GetComponent<Stats>().resilience)
		{
			int damage = (this.stats.willpower - target.GetComponent<Stats>().resilience);
			target.GetComponent<Stats>().TakeDamage(damage); 
		}
		
		else target.GetComponent<Stats>().TakeDamage(1);
	}
}

