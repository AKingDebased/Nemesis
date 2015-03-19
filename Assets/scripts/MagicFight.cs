using UnityEngine;
using System.Collections;

public class MagicFight : MonoBehaviour {
	public bool engaged = false;
	public GameObject currentTarget;
	
	private Stats stats;
	private float timeSinceLastAttack; 
	
	void Awake () {
		stats = gameObject.GetComponent<Stats>();
	}
	

}

