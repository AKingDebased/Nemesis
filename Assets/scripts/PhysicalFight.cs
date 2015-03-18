using UnityEngine;
using System.Collections;

public class PhysicalFight : MonoBehaviour 
{
	public AudioClip attackSound;

	private Stats stats;

	void Awake () 
	{
		stats = gameObject.GetComponent<Stats>();
	}
	
	public void Fight(GameObject currentTarget)
	{
		StartCoroutine(CoFight(currentTarget));
	}

	private IEnumerator CoFight(GameObject currentTarget)
	{
		float timeSinceLastAttack = 0.0f;
		bool engaged = true;
		Stats enemyStats = currentTarget.GetComponent<Stats>();

		while(engaged)
		{	
			if(this.stats.health < 0)
			{ 
				Debug.Log (gameObject.name + " falls!");
				Destroy(gameObject);
				engaged = false;
			}
			
			if(enemyStats.health < 0){
				Debug.Log (gameObject.name + " killed " + currentTarget.name);
				engaged = false;
			}

			if(timeSinceLastAttack > (stats.speed/10)){
				this.Attack(currentTarget); 
				Debug.Log (currentTarget.name + " health: " + enemyStats.health);
				Debug.Log(gameObject.name + " is attacking");
				timeSinceLastAttack = 0.0f;
			} else timeSinceLastAttack += Time.deltaTime;

			yield return null;
		}
	}

	public void ReportName()
	{
		Debug.Log (gameObject.name);
	}
	public void TakeDamage(int damage){
		this.stats.health -= damage;
	}

	private void Attack(GameObject currentTarget)
	{
		if (this.AttackHit(currentTarget)){
			Debug.Log (gameObject.name + " hit!");
			AudioSource.PlayClipAtPoint(attackSound,transform.position);
			this.DoDamage(currentTarget);
		} else {
			Debug.Log (gameObject.name + " miss!");
		}
	}
	
	private bool AttackHit(GameObject currentTarget)
	{
		return Random.Range (0, 100) + (this.stats.dexterity * 2) >= (currentTarget.GetComponent<Stats>().speed);
	}
	
	private void DoDamage (GameObject currentTarget)
	{
		if (this.stats.strength > currentTarget.GetComponent<Stats>().defense)
		{
			int damage = (this.stats.strength - currentTarget.GetComponent<Stats>().defense);
			
			if (this.IsCrit(currentTarget)) {
				Debug.Log (gameObject.name + " crits!");
				currentTarget.GetComponent<PhysicalFight>().TakeDamage(damage * (this.stats.dexterity /10));
			} else currentTarget.GetComponent<PhysicalFight>().TakeDamage(damage); //we need some sort of interface to for Fight behavior
		}
		
		else currentTarget.GetComponent<PhysicalFight>().TakeDamage(1);
	}
	
	private bool IsCrit(GameObject currentTarget)
	{
		return ((this.stats.dexterity / 2) + Random.Range (0, 100) > currentTarget.GetComponent<Stats>().dexterity * 2);
	}
	

}

