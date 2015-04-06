using UnityEngine;
using System.Collections;

public class FireProjectile : MonoBehaviour {
	public AudioClip fireSound;
	public GameObject projectileObj;
	public Transform launchPoint;
	public float speed = 1;

	private GameObject projectile;
	
	public void Fire(GameObject target){
		projectile = Instantiate(projectileObj, launchPoint.position, Quaternion.identity) as GameObject;
		projectile.GetComponent<FireTowardsTarget>().enabled = true;
		projectile.GetComponent<FireTowardsTarget>().target = target;
		AudioSource.PlayClipAtPoint(fireSound,transform.position);
	}
}
