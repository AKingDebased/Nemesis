using UnityEngine;
using System.Collections;

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
	}
	
	private void Attack(GameObject target){
		warriorSource.PlayOneShot(attackSound);
		this.DoDamage(target);
	}
	
	private void DoDamage (GameObject target){
		if (this.stats.strength > target.GetComponent<Stats>().defense){ 
			int damage = (Random.Range (1,this.stats.baseDamage + 1 ) + this.stats.strength - target.GetComponent<Stats>().defense);
			
			if (this.IsCrit(target)) {
				Debug.Log (gameObject.name + " crits!");
				target.GetComponent<Stats>().TakeDamage(damage * 2); //crit for double damage
			} else target.GetComponent<Stats>().TakeDamage(damage); 
		}
		
		else target.GetComponent<Stats>().TakeDamage(1);
	}
	
	private bool IsCrit(GameObject target){
		return ((this.stats.dexterity / 2) + UnityEngine.Random.Range (0, 100) > target.GetComponent<Stats>().dexterity * 2);
	}
	
	
}

