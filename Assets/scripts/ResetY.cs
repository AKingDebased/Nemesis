using UnityEngine;
using System.Collections;

public class ResetY : MonoBehaviour {

	// the ugliest bandage fix

	Vector3 yReset = new Vector3(0,2,0);

	void Update () {
		if(transform.position.y < -1){
			transform.position += yReset;
		}
	}
}
