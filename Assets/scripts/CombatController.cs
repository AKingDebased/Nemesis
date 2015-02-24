using UnityEngine;
using System.Collections;

public class CombatController : MonoBehaviour
{
	private bool combatEngaged;
	private float timeSinceLastAttack;

	private MinionCombatController currentEnemy;

	public AdventurerGeneration gen;
	
	void Start ()
	{	

		this.printStats();

		if (this.gen.GetArchetype ().Compare()
		{
			range = 5;
		}

		else range = 30;

		range = 5; //kludge fix

		timeSinceLastAttack = 0;
	}

	void Update ()
	{
		if (this.stats[0] <= 0)
		{
			Debug.Log("The hero has been killed!");
			Destroy(this.gameObject);
		}

		if (combatEngaged)
		{
			if (timeSinceLastAttack * 10 >= this.stats[6])
			{
				Debug.Log ("Hero attack!");
				this.attack(currentEnemy);
				timeSinceLastAttack = 0;
			}

			else timeSinceLastAttack += Time.deltaTime;

			if (currentEnemy.getStat(0) <= 0) combatEngaged = false;
		}
	}

	void attack(MinionCombatController enemy)
	{
		if (this.attackHit(enemy)) this.doDamage(enemy);
	}

	void doDamage(MinionCombatController enemy)
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

	bool attackHit(MinionCombatController enemy)
	{
		if (Random.Range(0, 100) + (thisstats[5] * 2) >= enemy.getStat(6)) return true;
		else return false;
	}

	bool isCrit(MinionCombatController enemy)
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

	void printStats()
	{
		Debug.Log("Stats--");
		for (int i = 0; i < stats.Length; i++)
		{
			Debug.Log(statNames[i] + ": " + stats[i]);
		}
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag ==  "minion")
		{
			currentEnemy = other.gameObject.GetComponent<MinionCombatController>();
			Debug.Log ("Hero enters combat!");
			combatEngaged = true;
		}
	}

}
	