using UnityEngine;
using System.Collections;

public class MinionCombatController : MonoBehaviour {

	private int[] stats = new int[] {100, 10, 10, 30, 10, 10, 40, 40, 20};
	private string[] statNames = new string[] {"Health", "Mana", "Morale", "Strength", "Willpower", "Dexterity", "Speed", "Defense", "Resilience"};
	private int range;
	private bool combatEngaged;
	private float timeSinceLastAttack;

	private CombatController currentEnemy;
	/*
	void Start () {
		range = 5;
		timeSinceLastAttack = 0;
		combatEngaged = false;
	}
	
	void Update ()
	{
		if (this.stats[0] <= 0)
		{
			Debug.Log("The minion has been killed!");
			Destroy(this.gameObject);
		}

		if (combatEngaged)
		{
			if (timeSinceLastAttack * 10 >= this.stats[6])
			{
				Debug.Log ("Minion attack!");
				this.attack(currentEnemy);
				timeSinceLastAttack = 0;
			}

			else timeSinceLastAttack += Time.deltaTime;

			if (currentEnemy.getStat(0) <= 0) combatEngaged = false;
		}
	}

	void attack(CombatController enemy)
	{
		if (this.attackHit(enemy)) this.doDamage(enemy);
	}

	void doDamage(CombatController enemy)
	{
		if (this.stats[3] > enemy.getStat(7))
		{
			int damage = (this.stats[3] - enemy.getStat(7));

			if (this.isCrit(enemy)) enemy.takeDamage(damage * (this.stats[5]/10));
			else enemy.takeDamage(damage);
		}
		
		else enemy.takeDamage(1);
	}

	public void takeDamage(int damage)
	{
		this.stats[0] -= damage;
	}

	bool attackHit(CombatController enemy)
	{
		if (Random.Range(0, 100) + (this.stats[5] * 2) >= enemy.getStat(6)) return true;
		else return false;
	}

	bool isCrit(CombatController enemy)
	{
		if ((this.stats[6] / 2) + Random.Range(0, 100) > enemy.getStat(5) * 2) return true;
		else return false;
	}

	bool inRange(GameObject target)
	{
		if (Vector3.Distance(target.transform.position, this.gameObject.transform.position) <= range) return true;
		else return false;
	}
	
	public int getStat(int x)
	{
		return this.stats[x];
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag ==  "hero")
		{
			currentEnemy = other.gameObject.GetComponent<AdventurerCombatController>();
			Debug.Log ("Minion enters combat!");
			combatEngaged = true;
		}
	}*/
}
	