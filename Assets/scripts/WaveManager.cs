using UnityEngine;
using System.Collections.Generic;

public class WaveManager : MonoBehaviour {
	bool waveStarted = false;

	public GameObject spawnPoint;
	public List<GameObject> adventurers = new List<GameObject>();

	public void StartWave(){
		if(!waveStarted){
			foreach (GameObject adventurer in adventurers){
				Instantiate(adventurer,spawnPoint.transform.position,Quaternion.identity);
			}
		}

		waveStarted = true;
		GameObject.Find ("minions").GetComponent<ResetMinions>().resettable = false; //MORE KLUDGE FIXES
	}
}
