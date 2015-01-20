using UnityEngine;
using System.Collections;

using Pathfinding;

public class AStarAI : MonoBehaviour {
	public Vector3 targetPosition;
	public Path path;
	public float speed = 100;
	public float nextWaypointDistance = 3;

	private int currentWaypoint = 0;
	private Seeker seeker;
	private CharacterController controller;

	public void Start () {
		seeker = GetComponent<Seeker>();
		controller = GetComponent<CharacterController>();

		seeker.pathCallback += OnPathComplete; //autocalls OnPathComplete for all StartPaths
		seeker.StartPath(transform.position, targetPosition);
	}

	public void OnPathComplete(Path p){
		Debug.Log ("path traced.");
		Debug.Log ("error in path: " + p.error);
		if(!p.error){
			path = p;
			currentWaypoint = 0;
		}
	}

	public void FixedUpdate(){
		moveToNextWaypoint();
	}

	public void OnDisable () {
		seeker.pathCallback -= OnPathComplete;
	}

	private void moveToNextWaypoint(){
		if(path == null){
			Debug.Log("i see you");
			return;
		}
		
		if(currentWaypoint >= path.vectorPath.Count){
			Debug.Log ("end of path reached");
			return;
		}
		
		Vector3 direction = (path.vectorPath[currentWaypoint] - transform.position).normalized;
		direction *= speed * Time.fixedDeltaTime;
		controller.SimpleMove(direction);

		if(Vector3.Distance (transform.position, path.vectorPath[currentWaypoint]) < nextWaypointDistance){
			currentWaypoint++;
			return;
		}

	}


}
