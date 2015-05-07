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
		this.Attack(target); 
	}
	
	private void Attack(GameObject target){
		warriorSource.PlayOneShot(attackSound);
		this.DoDamage(target);
	}
	
	private void DoDamage (GameObject target){
		int damage = (Random.Range (1,this.stats.baseDamage + 1 ) + this.stats.strength - target.GetComponent<Stats>().defense);
			
		if(damage > 0){
			if (this.IsCrit(target)) {
				Debug.Log (gameObject.name + " crits for " + damage * 2);
				target.GetComponent<Stats>().TakeDamage(damage * 2); //crit for double damage
			} else target.GetComponent<Stats>().TakeDamage(damage); 
			Debug.Log (gameObject.name + " does " + damage + " damage");
		}
		
		else target.GetComponent<Stats>().TakeDamage(1);
		Debug.Log (gameObject.name + " does 1 damage");
	}
	
	private bool IsCrit(GameObject target){
		return ((this.stats.dexterity / 2) + UnityEngine.Random.Range (0, 100) > target.GetComponent<Stats>().dexterity * 2);
	}
}

