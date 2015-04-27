﻿using UnityEngine;
using System.Collections;
//using System;

public class PhysicalCombat : MonoBehaviour {
	public AudioClip attackSound;
	private AudioSource warriorSource;
	private Stats stats;
	
	void Awake (){
		stats = gameObject.GetComponent<Stats>();
		warriorSource = this.GetComponent<AudioSource>();
	}

	public void Fight(GameObject target){
		Stats enemyStats = target.GetComponent<Stats>(); //does this need to be assigned every time Fight is called?
		
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
		//if (this.AttackHit(target)){
			warriorSource.PlayOneShot(attackSound);
			this.DoDamage(target);
		/*} else {
			Debug.Log (gameObject.name + " misses!");
		}*/
	}
	
	private void DoDamage (GameObject target){
		if (this.stats.strength > target.GetComponent<Stats>().defense){ 
			int damage = (Random.Range (1,this.stats.baseDamage) + this.stats.strength - target.GetComponent<Stats>().defense);
			
			if (this.IsCrit(target)) {
				target.GetComponent<Stats>().TakeDamage(damage * 2); //crit for double damage
			} else target.GetComponent<Stats>().TakeDamage(damage); 
		}
		
		else target.GetComponent<Stats>().TakeDamage(1);
	}
	
	private bool IsCrit(GameObject target){
		return ((this.stats.dexterity / 2) + UnityEngine.Random.Range (0, 100) > target.GetComponent<Stats>().dexterity * 2);
	}
	
	
}

