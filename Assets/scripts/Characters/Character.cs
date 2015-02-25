﻿using UnityEngine;
using System.Collections.Generic;

public abstract class Character : MonoBehaviour {

	public int range;
	private int threat;
	
	public Dictionary<string, int> stats = new Dictionary<string, int>();

	public void TakeDamage(int damage){
		this.stats["health"] -= damage;
	}
}