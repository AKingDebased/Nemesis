using UnityEngine;
using System.Collections;

using Pathfinding;

public class HeroMovement : MonoBehaviour {
	public Vector3 targetPosition;
	public Path path;
	public float speed = 100;
	public float nextWaypointDistance = 3;

	private GameObject[] objectRooms;
	private Transform[] rooms;
	private Seeker seeker;
	private CharacterController controller;
	
	public void Start () {
		seeker = GetComponent<Seeker>();
		controller = GetComponent<CharacterController>();

		for(int i = 0; i < objectRooms.Length; i++){
			rooms[i] = objectRooms[i].transform;
		}
		
		seeker.pathCallback += OnPathComplete; //autocalls OnPathComplete for all StartPaths
	}
	
	public void OnPathComplete(Path p){
		/*Debug.Log ("path traced.");
		Debug.Log ("error in path: " + p.error);
		if(!p.error){
			path = p;
			currentWaypoint = 0;
		}*/
	}
	
	public void FixedUpdate(){
		MoveToNextRoom();
	}
	
	public void OnDisable () {
		seeker.pathCallback -= OnPathComplete;
	}

	private void MoveToNextRoom(){
		/*if(currentWaypoint >= path.vectorPath.Count){
			Debug.Log ("end of path reached");
			return;
		}
		
		Vector3 direction = (path.vectorPath[currentWaypoint] - transform.position).normalized;
		direction *= speed * Time.fixedDeltaTime;
		controller.SimpleMove(direction);
		
		if(Vector3.Distance (transform.position, path.vectorPath[currentWaypoint]) < nextWaypointDistance){
			currentWaypoint++;
			return;
		}*/
		
	}

	private Transform GetClosestRoom (Transform[] rooms) //courtesy of edwardrowe on the unity forums
	{
		Transform closestRoom = null;
		float closestDistanceSqr = Mathf.Infinity;
		Vector3 currentPosition = transform.position;

		foreach(Transform potentialRoom in rooms)
		{
			Vector3 directionToRoom = potentialRoom.position - currentPosition;
			float directionSqrdToRoom = directionToRoom.sqrMagnitude;

			if(directionSqrdToRoom < closestDistanceSqr)
			{
				closestDistanceSqr = directionSqrdToRoom;
				closestRoom = potentialRoom;
			}
		}
		
		return closestRoom;
	}
}
