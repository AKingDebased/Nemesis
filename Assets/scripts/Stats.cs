using UnityEngine;
using System.Collections.Generic;

public class Stats : MonoBehaviour {
	
	public Dictionary<string, string> advInfo = new Dictionary<string, string>();
	
	public int health;
	public int mana;
	public int gumption;
	public int strength;
	public int willpower;
	public int dexterity;
	public int speed;
	public int defense;
	public int resilience;
	
	
	
	void Awake(){
		advInfo = AdventurerGenerator.FreshHero();

		if(gameObject.name == "warrior"){
			health = 100;
			mana = 100;
			gumption = 100;
			strength = 50;
			willpower = 50;
			dexterity = 40;
			speed = 65;
			defense = 20;
			resilience = 40;
		} 

		if(gameObject.name == "grunt"){
			health = 100;
			mana = 100;
			gumption = 100;
			strength = 20;
			willpower = 20;
			dexterity = 20;
			speed = 50;
			defense = 10;
			resilience = 20;
		}

		if(gameObject.name == "BigGrunt"){
			health = 150;
			mana = 100;
			gumption = 100;
			strength = 30;
			willpower = 30;
			dexterity = 30;
			speed = 60;
			defense = 20;
			resilience = 20;
		}
	}
}
