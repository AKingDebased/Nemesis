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
		objectRooms = GameObject.FindGameObjectsWithTag("room");
		rooms = new Transform[objectRooms.Length]; //stored rooms' position

		for(int i = 0; i < objectRooms.Length; i++){
			rooms[i] = objectRooms[i].transform;
		}

		OrderRoomsNearToFar(rooms);

		for(int i = 0; i < rooms.Length; i++){
			Debug.Log (rooms);
		}
		
		seeker.pathCallback += OnPathComplete; 
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

	private Transform[] OrderRoomsNearToFar (Transform[] rooms) //courtesy of edwardrowe on the unity forums
	{
		Transform[] orderedRooms = null;
		float closestDistanceSqr = Mathf.Infinity;
		Vector3 currentPosition = transform.position;

		for(int i = 0; i < rooms.Length; i++){
			Vector3 directionToRoom = rooms[i].position - currentPosition;

			if(directionSqrdToRoom < closestDistanceSqr)
			{
				closestDistanceSqr = directionSqrdToRoom;
				closestRoom = potentialRoom;
			}
		}
		
		return closestRoom;
	}
}
