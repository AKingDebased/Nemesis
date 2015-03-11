using UnityEngine;
using System.Collections;

public class FireProjectile : MonoBehaviour {
	public AudioClip fireSound;
	public GameObject projectileObj;
	public GameObject target;
	public float speed = 1;
	
	private GameObject projectile;
	
	void Start () {
		projectile = Instantiate(projectileObj, transform.position, Quaternion.identity) as GameObject;
		projectile.GetComponent<FireTowardsTarget>().target = target;
		AudioSource.PlayClipAtPoint(fireSound,transform.position);
	}
}
