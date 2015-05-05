using UnityEngine;
using System.Collections;

public class KillTorches : MonoBehaviour {

	private ParticleEmitter[] torches;

	// Use this for initialization
	void Start () {
		torches = this.GetComponentsInChildren<ParticleEmitter>();
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyUp("space"))
			for (int i = 0; i < torches.Length; i++)
				torches [i].emit = false;
	}
}
