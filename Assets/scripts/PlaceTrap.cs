using UnityEngine;
using System.Collections;

public class PlaceTrap : MonoBehaviour {

	/*void Update () {
		Vector3 mouse = Input.mousePosition;
		//mouse = new Vector3(mouse.x, mouse.y, transform.position.y);
		Vector3 point = Camera.main.ScreenToWorldPoint(mouse);
		transform.position = new Vector3(point.x, (float) 0.005, point.z);
			
		if (Input.GetMouseButtonDown(0)) {
			gameObject.GetComponent<BoxCollider>().enabled = true;
			Cursor.visible = true;
		}
	}*/

	void Update(){
		Vector3 mouse = Input.mousePosition;
		mouse = new Vector3(mouse.x,mouse.y,transform.position.z);
		Vector3 worldPoint = Camera.main.ScreenToWorldPoint(mouse);

		transform.position = new Vector3(worldPoint.x, 1.0f,worldPoint.z);
	}
}
