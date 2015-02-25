using UnityEngine;
using System.Collections.Generic;

public abstract class Adventurer : Character {

	public Dictionary<string, string> advInfo = new Dictionary<string, string>();

	private int gumption;

	public abstract void Attack(Minion minion);

	void Awake(){
		advInfo.Add ("name", null);
		advInfo.Add ("homeland", null);
		advInfo.Add ("archetype", null);
		advInfo.Add ("advClass", null);
		advInfo.Add ("gender", null);
	}


}


