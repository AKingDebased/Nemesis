using UnityEngine;
using System.Collections;

using UnityEngine.UI;

public class TrapPlacement : MonoBehaviour {

	private GameObject trap;
	public Camera gameCamera;

	void Update () {
		if (GameObject.Find("Trap(Clone)")) {
			Vector3 mouse = Input.mousePosition;
			mouse = new Vector3(mouse.x, mouse.y, transform.position.y);
			Vector3 point = gameCamera.ScreenToWorldPoint(mouse);
			trap.transform.position = new Vector3(point.x, (float) 0.005, point.z);
		}
	}

	public void NewTrap() {
		trap = (GameObject)Instantiate (Resources.Load ("Trap"));
		trap.GetComponent<BoxCollider>().enabled = !trap.GetComponent<BoxCollider>().enabled;
		Cursor.visible = false;
	}
}