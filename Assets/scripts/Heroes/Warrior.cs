using UnityEngine;
using System.Collections;

public class Warrior : MonoBehaviour {



	void Start(){
		range = 5;
	}
	private int[] stats = new int[] {100, 100, 100, 50, 50, 50, 20, 30, 40};
	private string[] statNames = new string[] {"Health", "Mana", "Morale", "Strength", "Willpower", "Dexterity", "Speed", "Defense", "Resilience"};
	private int range;
}
