using UnityEngine;
using System.Collections.Generic;

using Pathfinding;

public class HeroMovement : MonoBehaviour { //courtesy of aron granberg

	public List<Transform> rooms = new List<Transform>();
	public float speed = 50f;
	
	private WaypointPath waypointPath;
	private Vector3[] roomWaypoints;
	private int currentWaypoint = 0;
	private ABPath[] pathSegments;

	private CharacterController controller;

	public void Start () {
		controller = GetComponent<CharacterController>();

		roomWaypoints = new Vector3[rooms.Count];
		currentWaypoint = 0;

		for(int i = 0; i < rooms.Count; i++){
			roomWaypoints[i] = rooms[i].position;
		}
		
		//Start a new waypointPath to the targetPosition, return the result to the OnPathComplete function
		waypointPath = new WaypointPath(roomWaypoints, OnPathComplete);
		waypointPath.StartPath();

		pathSegments = waypointPath.getPaths();
	}

	public void Update () {
		if (waypointPath == null) {
			return;
		}
		
		/*if (currentWaypoint == waypointPath.getPaths[Length-1].vectorPath.Count) {
			Debug.Log ("end of path");
			currentWaypoint++;
			return;
		}*/

		for(int i = 0; i < pathSegments.Length-1; i++){
			//Direction to the next waypoint
			Vector3 dir = (pathSegments[i].vectorPath[currentWaypoint]-transform.position).normalized;
			dir *= speed;//* Time.deltaTime;
			//transform.Translate (dir);
			controller.SimpleMove (dir);
		}
	}

	void OnPathComplete (WaypointPath p) {
		if (p.HasError ()) {
			Debug.LogError ("Noes, could not find the waypointPath!");
			return;
		} else {
			List<Vector3> vp = p.vectorPath;
			for (int i=0;i<vp.Count-1;i++) Debug.DrawLine (vp[i],vp[i+1],Color.green,2);
		}
	}
}