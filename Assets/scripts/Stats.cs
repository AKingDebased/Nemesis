using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class Stats : MonoBehaviour {
	
	public Dictionary<string, string> advInfo = new Dictionary<string, string>();
	public Slider healthBar;
	
	public int health = 0;
	public int mana = 0;
	public int gumption = 0;
	public int strength = 0;
	public int willpower = 0;
	public int dexterity = 0;
	public int speed = 0;
	public int defense = 0;
	public int resilience = 0;
	public int range = 0;

	void Start(){
		if(gameObject.tag != "minion"){
			SetHealthBar(health);
		} //naive fix to ignore minions
	}

	public void TakeDamage(int damage){
		this.health -= damage;

		if(gameObject.tag != "minion"){ //naive fix to ignore minions
			healthBar.value -= damage;
		}
	}

	private void SetHealthBar(int health){
		healthBar.maxValue = health;
		healthBar.value = health;
	}
	
}
