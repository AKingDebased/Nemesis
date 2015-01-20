using UnityEngine;
using System.Collections;

using Pathfinding;

public class AStarAI : MonoBehaviour {
	public Vector3 targetPosition;
	
	void Start () {
		Seeker seeker = GetComponent<Seeker>();

		seeker.StartPath(transform.position, targetPosition, OnPathComplete);
	}

	void OnPathComplete(Path p){
		Debug.Log ("path traced.");
		Debug.Log ("errors: " + p.error);
	}
}
