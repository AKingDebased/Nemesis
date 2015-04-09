using UnityEngine;
using System.Collections.Generic;

public class TargetManager : MonoBehaviour {

	public Dictionary<GameObject, float> targets = new Dictionary<GameObject, float>();
	
	void Update () {
		if (Input.GetKeyDown("space")){
			ReportTargets ();
		}
	}

	public void AddTarget(GameObject target, float threat){
		targets.Add(target,threat);
	}

	private void ReportTargets(){

		foreach(KeyValuePair<GameObject, float> target in targets){
			Debug.Log(target.Key.name + " has threat of " + target.Value);
		}
	}
}
