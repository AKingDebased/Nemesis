using UnityEngine;
using System.Collections.Generic;

using Pathfinding;

public class HeroMovement : MonoBehaviour {
	public List<GameObject> rooms = new List<GameObject>();

	private Seeker seeker;
	private CharacterController controller;
	private Vector3[] roomWaypoints;
	private ABPath[] paths;
	 
	public void Start () {
		seeker = GetComponent<Seeker>();
		controller = GetComponent<CharacterController>();

		seeker.pathCallback += OnPathComplete;

		//waypoints hey
		roomWaypoints = new Vector3[rooms.Count];

		for(int i = 0; i < rooms.Count; i++){
			roomWaypoints[i] = rooms[i].transform.position;
		}                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    
	}

	public void StartPath (OnPathDelegate config = null){
		paths = new ABPath[roomWaypoints.Length-1];

		for (int i=0;i<paths.Length;i++) {
			paths[i] = ABPath.Construct (roomWaypoints[i],roomWaypoints[i+1], OnPathComplete);
			seeker.StartPath (paths[i]);
		}
	}

	public void OnPathComplete(Path p){
		/*Debug.Log ("path traced.");
		Debug.Log ("error in path: " + p.error);
		if(!p.error){
			path = p;
			currentWaypoint = 0;
		}*/
	}             

	public void OnDisable () {
		seeker.pathCallback -= OnPathComplete;
	}
}
