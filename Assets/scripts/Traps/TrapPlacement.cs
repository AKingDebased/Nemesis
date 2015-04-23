using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class TrapPlacement : MonoBehaviour {

	private GameObject trap;
	
	void Update () {
		if (GameObject.Find("trap(Clone)")) {
			Vector3 mouse = Input.mousePosition;
			mouse = new Vector3(mouse.x, mouse.y, transform.position.y);
			Vector3 point = Camera.main.ScreenToWorldPoint(mouse); //defaults to main camera
			trap.transform.position = new Vector3(point.x, (float) 0.005, point.z);
		}
	}

	public void NewTrap() {
		trap = (GameObject)Instantiate (Resources.Load ("trap"));
		trap.GetComponent<BoxCollider>().enabled = !trap.GetComponent<BoxCollider>().enabled;
		Cursor.visible = false;
	}
}