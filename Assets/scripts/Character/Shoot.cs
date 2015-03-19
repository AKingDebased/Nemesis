using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

	public GameObject projectile;

	void Start () {
		Instantiate(projectile, transform.position, Quaternion.identity);
	}
}
