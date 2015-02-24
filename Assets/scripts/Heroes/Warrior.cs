using UnityEngine;
using System.Collections;

public class Warrior : Adventurer{

	void Awake(){
		rangeAttribute = 5;

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
}
