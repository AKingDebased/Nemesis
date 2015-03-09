using UnityEngine;
using System.Collections;

public class Fight : MonoBehaviour {
	public bool engaged = false;
	public GameObject currentTarget;
	
	private Stats stats;
	private float timeSinceLastAttack; 
	
	void Awake () {
		stats = gameObject.GetComponent<Stats>();
	}
	
	void Update () {
		if(engaged){
			if (timeSinceLastAttack * 10 >= stats.speed)
			{
				this.Attack(currentTarget); 
				Debug.Log (currentTarget.name + " health: " + currentTarget.GetComponent<Stats>().health);
				timeSinceLastAttack = 0;				
			} else timeSinceLastAttack += Time.deltaTime;

			if(this.stats.health < 0){ //needs to disengage after the last enemy in a group is killed
				Debug.Log (gameObject.name + " falls!");
				Destroy(gameObject);
				engaged = false;
			}
		}
	}
	
	private void Attack(GameObject currentTarget){
		if (this.AttackHit(currentTarget)){
			Debug.Log (gameObject.name + " hit!");
			GetComponent<AudioSource>().Play();
			this.DoDamage(currentTarget);
		} else {
			Debug.Log (gameObject.name + " miss!");
		}
	}
	
	private bool AttackHit(GameObject currentTarget){
		return Random.Range (0, 100) + (this.stats.dexterity * 2) >= (currentTarget.GetComponent<Stats>().speed);
	}
	
	private void DoDamage (GameObject currentTarget){
		if (this.stats.strength > currentTarget.GetComponent<Stats>().defense)
		{
			int damage = (this.stats.strength - currentTarget.GetComponent<Stats>().defense);
			
			if (this.IsCrit(currentTarget)) {
				Debug.Log (gameObject.name + " crits!");
				currentTarget.GetComponent<Fight>().TakeDamage(damage * (this.stats.dexterity /10));
			} else currentTarget.GetComponent<Fight>().TakeDamage(damage);
		}
		
		else currentTarget.GetComponent<Fight>().TakeDamage(1);
	}
	
	private bool IsCrit(GameObject currentTarget)
	{
		return ((this.stats.dexterity / 2) + Random.Range (0, 100) > currentTarget.GetComponent<Stats>().dexterity * 2);
	}

	private void TakeDamage(int damage){
		this.stats.health -= damage;
	}
	
	/*private bool InRange(GameObject currentTarget)
	{
		if (Vector3.Distance(currentTarget.transform.position, this.gameObject.transform.position) <= range) return true;
		else return false;
	}*/
}

