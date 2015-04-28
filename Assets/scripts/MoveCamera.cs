using UnityEngine;
using System.Collections;

public class MoveCamera : MonoBehaviour {

	public int leftBorder = 0;
	public int rightBorder = 0;
	public int bottomBorder = 0;
	public int topBorder = 0;

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
		transform.position = new Vector3(Mathf.Clamp(transform.position.x,leftBorder,rightBorder),transform.position.y,
		                                 Mathf.Clamp (transform.position.z,bottomBorder,topBorder));
	}
}
