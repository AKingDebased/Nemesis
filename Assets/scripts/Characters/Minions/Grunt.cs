using UnityEngine;
using System.Collections.Generic;

public class Grunt : Minion {
	public GameObject testAdvObject;
	public Warrior testAdv;
	public float timeSinceLastAttack = 0;

	void Awake(){
		stats.Add ("health", 100);
		stats.Add ("mana", 100);
		stats.Add ("morale", 100);
		stats.Add ("strength", 20);
		stats.Add ("willpower", 20);
		stats.Add ("dexterity", 30);
		stats.Add ("speed", 50);
		stats.Add ("defense", 20);
		stats.Add ("resilience", 20);

		testAdv = testAdvObject.GetComponent<Warrior>();
	}

	public void Update(){
		if (timeSinceLastAttack * 10 >= stats["speed"])
		{
			this.Attack(testAdv);
			Debug.Log ("warrior health: " + testAdv.stats["health"]);
			timeSinceLastAttack = 0;				
		} else timeSinceLastAttack += Time.deltaTime;

		
		if(stats["health"] < 0){
			Debug.Log ("grunt falls!");
			Destroy(gameObject);
		}
	}

	public override void Attack(Character target){
		if (this.AttackHit(target)){
			Debug.Log ("grunt hit!");
			this.DoDamage(target);
		} else {
			Debug.Log ("grunt miss!");
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
				Debug.Log ("GRUNT CRIT BABY");
				target.TakeDamage(damage * (this.stats["dexterity"]/10));
			} else target.TakeDamage(damage);
		}
		
		else target.TakeDamage(1);
	}
	
	private bool IsCrit(Character target)
	{
		return ((this.stats ["dexterity"] / 2) + Random.Range (0, 100) > target.stats ["dexterity"] * 2);
	}
}
