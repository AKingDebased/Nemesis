using UnityEngine;
using System.Collections;

public abstract class Adventurer : MonoBehaviour {

	private string homeland;
	private string archetype;
	private string heroClass;
	private string gender;

	private int range;

	Dictionary<string, int> stats = new Dictionary<string, int>();
	
	public abstract void Attack(Enemy enemy);

	protected abstract void DoDamage(Enemy enemy);

	protected abstract void TakeDamage(int damage);


