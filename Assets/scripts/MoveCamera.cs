using UnityEngine;
using System.Collections;

public class MoveCamera : MonoBehaviour {

	public int zMin = 0;
	public int zMax = 0;
	public int xMin = 0;
	public int xMax = 0;

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

		ClampCameraZ();

	}

	void ClampCameraZ(){
		transform.position = new Vector3(Mathf.Clamp(transform.position.x,xMin,xMax),transform.position.y,
		                                 Mathf.Clamp (transform.position.z,zMin,zMax));
	}
}
