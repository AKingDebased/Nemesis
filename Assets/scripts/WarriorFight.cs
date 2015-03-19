using UnityEngine;
using System.Collections;
using System;

public class WarriorFight : MonoBehaviour {
	public AudioClip attackSound;

	private Stats stats;
	
	void Awake (){
		stats = gameObject.GetComponent<Stats>();
	}

	/*public void Fight(GameObject target, Action onComplete){
		StartCoroutine(CoFight(target, onComplete));
	}

	private IEnumerator CoFight(GameObject target, Action onComplete){
		float timeSinceLastAttack = 0.0f;
		bool engaged = true;
		Stats enemyStats = target.GetComponent<Stats>();

		while(engaged){	
			if(this.stats.health < 0){ 
				Debug.Log (gameObject.name + " falls!");
				Destroy(gameObject);
				engaged = false;
				onComplete();
			}
			
			if(enemyStats.health < 0){
				Debug.Log (gameObject.name + " killed " + target.name);
				engaged = false;

				onComplete();
			}

			if(timeSinceLastAttack > (stats.speed/10)){
				this.Attack(target); 
				Debug.Log (target.name + " health: " + enemyStats.health);
				timeSinceLastAttack = 0.0f;
			} else timeSinceLastAttack += Time.deltaTime;

			yield return null;
		}
	}*/

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

	public void TakeDamage(int damage){
		this.stats.health -= damage;
	}

	private void Attack(GameObject target){
		if (this.AttackHit(target)){
			Debug.Log (gameObject.name + " hits!");
			AudioSource.PlayClipAtPoint(attackSound,transform.position);
			this.DoDamage(target);
		} else {
			Debug.Log (gameObject.name + " misses!");
		}
	}
	
	private bool AttackHit(GameObject target){
		return UnityEngine.Random.Range (0, 100) + (this.stats.dexterity * 2) >= (target.GetComponent<Stats>().speed);
	}
	
	private void DoDamage (GameObject target){
		if (this.stats.strength > target.GetComponent<Stats>().defense)
		{
			int damage = (this.stats.strength - target.GetComponent<Stats>().defense);
			
			if (this.IsCrit(target)) {
				Debug.Log (gameObject.name + " crits!");
				target.GetComponent<WarriorFight>().TakeDamage(damage * (this.stats.dexterity /10));
			} else target.GetComponent<WarriorFight>().TakeDamage(damage); 
		}
		
		else target.GetComponent<WarriorFight>().TakeDamage(1);
	}
	
	private bool IsCrit(GameObject target){
		return ((this.stats.dexterity / 2) + UnityEngine.Random.Range (0, 100) > target.GetComponent<Stats>().dexterity * 2);
	}
	

}

