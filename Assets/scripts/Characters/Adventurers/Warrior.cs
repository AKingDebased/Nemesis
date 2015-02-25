using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Warrior : Adventurer {
	public GameObject testMinionObject;
	public Grunt testMinion;
	public float timeSinceLastAttack = 0;

	void Awake(){
		range = 5;

		advInfo = AdventurerGenerator.FreshHero();

		stats.Add ("health", 100);
		stats.Add ("mana", 100);
		stats.Add ("morale", 100);
		stats.Add ("strength", 50);
		stats.Add ("willpower", 50);
		stats.Add ("dexterity", 50);
		stats.Add ("speed", 50);
		stats.Add ("defense", 20);
		stats.Add ("resilience", 40);

		testMinion = testMinionObject.GetComponent<Grunt>();
	}

	public void Update(){
		if (timeSinceLastAttack * 10 >= stats["speed"])
		{
			this.Attack(testMinion);
			Debug.Log ("grunt health: " + testMinion.stats["health"]);
			timeSinceLastAttack = 0;				
		} else timeSinceLastAttack += Time.deltaTime;

		
		if(stats["health"] < 0){
			Debug.Log ("warrior falls!");
			Destroy(gameObject);
		}
	}

	public override void Attack(Character target){
		if (this.AttackHit(target)){
			Debug.Log ("warrior hit!");
			this.DoDamage(target);
		} else {
			Debug.Log ("warrior miss!");
		}
	}

	private bool AttackHit(Character target){
		return (Random.Range (0, 100) + (this.stats ["dexterity"] * 2) >= target.stats["speed"]);
	}

	private void DoDamage (Character target){
		if (this.stats["strength"] > target.stats["defense"])
		{
			int damage = (this.stats["strength"] - target.stats["defense"]);
			
			if (this.IsCrit(target)) {
				Debug.Log ("WARRIOR CRIT BABY");
				target.TakeDamage(damage * (this.stats["dexterity"]/10));
			} else target.TakeDamage(damage);
		}
		
		else target.TakeDamage(1);
	}

	private bool IsCrit(Character target)
	{
		return ((this.stats ["dexterity"] / 2) + Random.Range (0, 100) > target.stats ["dexterity"] * 2);
	}

	/*private bool InRange(GameObject target)
	{
		if (Vector3.Distance(target.transform.position, this.gameObject.transform.position) <= range) return true;
		else return false;
	}*/
}
