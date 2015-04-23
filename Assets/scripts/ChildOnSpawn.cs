using UnityEngine;
using System.Collections;

public class ChildOnSpawn : MonoBehaviour {

	void Start () {
		Transform parent = GameObject.Find ("minions").transform;
		transform.parent = parent;
	}
}
