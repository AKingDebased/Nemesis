using UnityEngine;
using System.Collections.Generic;

public abstract class Adventurer : MonoBehaviour {

	private string homeland;
	private string archetype;
	private string heroClass;
	private string gender;

	private int range;

	public Dictionary<string, int> stats = new Dictionary<string, int>();
	
	public abstract void Attack(Enemy enemy){
		if (this.attackHit (enemy)) this.doDamage (enemy);
	}

	protected abstract void DoDamage(Enemy enemy){

	}

	protected abstract void TakeDamage(int damage);

	protected bool attackHit(MinionCombatController enemy)
	{
		if (Random.Range(0, 100) + (thisstats[5] * 2) >= enemy.getStat(6)) return true;
		else return false;
	}
}


