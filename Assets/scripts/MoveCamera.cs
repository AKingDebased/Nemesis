using UnityEngine;
using System.Collections;

public class MoveCamera : MonoBehaviour {

	void Update () {
		if(Input.mousePosition.x >= Screen.width){
			Vector3 newX = new Vector3(1,0,0);

			transform.position += newX;
		}

		if(Input.mousePosition.x <= 1){
			Vector3 newX = new Vector3(-1,0,0);
			
			transform.position += newX;
		}

		if(Input.mousePosition.y >= Screen.height){
			Vector3 newZ = new Vector3(0,0,1);
			
			transform.position += newZ;
		}

		if(Input.mousePosition.y <= 1){
			Vector3 newZ = new Vector3(0,0,-1);
			
			transform.position += newZ;
		}
	}
}
