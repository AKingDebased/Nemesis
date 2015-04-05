using UnityEngine;
using System.Collections;

public class LoadSceneOnKeyPress : MonoBehaviour {
	
	public bool anyKey;
	public Object scene; //not typesafe

	void Update () {
		if(anyKey){
			if (Input.anyKey){
				Application.LoadLevel(scene.name);
			}
		}
	}
}
