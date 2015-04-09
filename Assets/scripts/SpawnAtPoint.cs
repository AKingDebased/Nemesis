using UnityEngine;
using System.Collections;

public class SpawnAtPoint : MonoBehaviour {
	Ray ray;
	RaycastHit hit;

	public GameObject character;

	void Update () {
		if (Input.GetMouseButtonDown(0)){
			if(Physics.Raycast(Camera.main.ScreenPointToRay(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 0)), out hit)){

				Instantiate (character, hit.point,Quaternion.identity);
			}
		}
	}
}
