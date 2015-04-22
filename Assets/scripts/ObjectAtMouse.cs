using UnityEngine;
using System.Collections;

public class ObjectAtMouse : MonoBehaviour {
	
	void Update () {
		Vector3 mouse = Input.mousePosition;
		
		transform.position = Camera.main.ScreenToWorldPoint(new Vector3(mouse.x, (float) 0.005, mouse.z));
		Debug.Log (transform.position);

	}
}
