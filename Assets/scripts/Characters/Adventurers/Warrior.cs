using UnityEngine;
using System.Collections;

public class Warrior : Adventurer {

	void Awake(){
		range = 5;

		stats.Add ("health", 100);
		stats.Add ("mana", 100);
		stats.Add ("morale", 100);
		stats.Add ("strength", 50);
		stats.Add ("willpower", 50);
		stats.Add ("dexterity", 50);
		stats.Add ("speed", 20);
		stats.Add ("defense", 30);
		stats.Add ("resilience", 40);

	}

	public override void Attack(Minion minion){
		if (this.AttackHit(minion)) this.DoDamage(minion);
	}

	private bool AttackHit(Minion minion){
		if (Random.Range (0, 100) + (this.stats ["dexterity"] * 2) >= minion.stats["dexterity"]) {
			return true;
		} else return false;
		
	}

	private void DoDamage (Minion minion){
		if (this.stats["strength"] > minion.stats["defense"])
		{
			int damage = (this.stats["strength"] - minion.stats["defense"]);
			
			if (this.isCrit(minion)) {
				minion.TakeDamage(damage * (this.stats["dexterity"]/10));
			} else minion.TakeDamage(damage);
		}
		
		else minion.TakeDamage(1);
	}

	private bool isCrit(Minion minion)
	{
		if ((this.stats ["dexterity"] / 2) + Random.Range (0, 100) > minion.stats ["dexterity"] * 2) {
			return true;
		} else return false;
	}

	/*private bool InRange(GameObject target)
	{
		if (Vector3.Distance(target.transform.position, this.gameObject.transform.position) <= range) return true;
		else return false;
	}*/
}
