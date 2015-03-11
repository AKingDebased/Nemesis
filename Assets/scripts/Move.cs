using UnityEngine;
using System.Collections;

public class Move : MonoBehaviour {
	public float speed;
	public Transform target;

	void Awake(){
		target 
	}

	void Update () {
		float step = speed * Time.deltaTime;
		Vector3 newPos = new Vector3();

		transform.position = Vector3.MoveTowards(transform.position, target.position, step);
	}
}
