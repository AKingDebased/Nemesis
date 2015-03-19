using UnityEngine;
using System.Collections;

public class ReportStats : MonoBehaviour {

	private Stats myStats;

	void Start () {
		myStats = gameObject.GetComponent<Stats>();
	}

	void Update(){
		if (Input.GetKeyDown("space")){
			Debug.Log(gameObject.name);
			Debug.Log(myStats.health);
			Debug.Log(myStats.mana);
			Debug.Log(myStats.gumption);
			Debug.Log(myStats.strength);
			Debug.Log(myStats.willpower);
			Debug.Log(myStats.dexterity);
			Debug.Log(myStats.speed);
			Debug.Log(myStats.defense);
			Debug.Log(myStats.resilience);
		}
	}
}
