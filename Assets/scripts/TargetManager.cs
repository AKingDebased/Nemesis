using UnityEngine;
using System.Collections.Generic;

public class TargetManager : MonoBehaviour {

	public Dictionary<GameObject, float> targets = new Dictionary<GameObject, float>();
	private int[] testArray = new int[2];

	void Update () {
		if (Input.GetKeyDown("space")){
			ReportTargets ();
		}
	}

	public void AddTarget(GameObject target, float threat){
		Debug.Log ("adding " + target + " with threat " + threat);
		targets.Add(target,threat);
	}

	private void ReportTargets(){
		foreach(int testInt in testArray){
			Debug.Log(testInt);
		}
	}
}
