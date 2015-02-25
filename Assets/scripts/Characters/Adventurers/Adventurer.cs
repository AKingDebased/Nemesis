using UnityEngine;
using System.Collections.Generic;

public abstract class Adventurer : Character {

	public Dictionary<string, string> advInfo = new Dictionary<string, string>();

	private int gumption;

	public abstract void Attack(Minion minion);
}


