using UnityEngine;
using System.Collections.Generic;

using Pathfinding;

public class HeroMovement : MonoBehaviour { //courtesy of aron granberg

	public List<Transform> rooms = new List<Transform>();
	public float speed = 50f;
	
	private WaypointPath path;
	private Vector3[] roomWaypoints;
	private int currentNode = 0;

	private CharacterController controller;

	private float nextNodeDistance = 1.0f;

	public void Start () {
		controller = GetComponent<CharacterController>();

		roomWaypoints = new Vector3[rooms.Count];
		currentNode = 0;

		for(int i = 0; i < rooms.Count; i++){
			roomWaypoints[i] = rooms[i].position;
		}
		
		//Start a new path to the targetPosition, return the result to the OnPathComplete function
		path = new WaypointPath(roomWaypoints, OnPathComplete);
		path.StartPath();
	
	}

	public void Update () {
		if (path == null) {
			//We have no path to move after yet
			return;
		}


		if (currentNode > path.vectorPath.Count) return;


		if (currentNode == path.vectorPath.Count) {
			Debug.Log ("End Of Path Reached");
			currentNode++;
			return;
		}
		//Direction to the next waypoint
		Vector3 dir = (path.vectorPath[currentNode]-transform.position).normalized;
		dir *= speed;// * Time.deltaTime;
		//transform.Translate (dir);
		controller.SimpleMove (dir);

		if ( (transform.position-path.vectorPath[currentNode]).sqrMagnitude < nextNodeDistance*nextNodeDistance) {
			currentNode++;
			Debug.Log (currentNode);
			return;
		}

		Debug.Log (currentNode);
	}

	void OnPathComplete (WaypointPath p) {
		if (p.HasError ()) {
			Debug.LogError ("Noes, could not find the path!");
			return;
		} else {
			List<Vector3> vp = p.vectorPath;
			for (int i=0;i<vp.Count-1;i++) Debug.DrawLine (vp[i],vp[i+1],Color.green,2);
		}
	}
}