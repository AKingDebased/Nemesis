using UnityEngine;
using System.Collections.Generic;

public abstract class Character : MonoBehaviour {

	public int range;
	public Dictionary<string, int> threats = new Dictionary<string, int>();
	
	public Dictionary<string, int> stats = new Dictionary<string, int>();

	public abstract void Attack(Character target);

	public void TakeDamage(int damage){
		this.stats["health"] -= damage;
	}
}
